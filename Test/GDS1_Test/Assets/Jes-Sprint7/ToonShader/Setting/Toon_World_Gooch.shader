Shader "Custom/WorldToon"
{
    Properties
    {
		_BaseColor("Base Colour", Color) = (0.9622642, 0.4336322, 0.27597, 1)
        _HighlightColor("Highlight Colour", Color) = (1,1,1,1)
        _NbrShades("Number of Shades",int) = 3
        _SpecCoef("Specular Amount", float) = 0.06
        _SpecPower("Specular Power", float) = 20
        _HighlightThreshold("Highlight Threshold [0,1] (above shading thresh)", float) = 0.92
        _UseShadows("Use Shadows [0-false, 1-true]", int) = 1
        _ShadowThreshold("Shadow threshold", float) = 0.5
        _MainTex("Texture",2D) = "white"{}
    }
    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline"
        "RenderType"="Opaque"
		"Queue"="Geometry" }
        
        HLSLINCLUDE
		#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

		CBUFFER_START(UnityPerMaterial)
		float4 _BaseColor;
        float4 _HighlightColor;
        int _NbrShades;
        float _SpecCoef;
        float _SpecPower;
        float _HighlightThreshold;
        uint _UseShadows;
        float _ShadowThreshold;
        float4 _MainTex_ST;
		CBUFFER_END

        struct Attributes {
            float4 positionOS   : POSITION;
            float4 normalOS     : NORMAL;
            float4 tangentOS    : TANGENT;
            float2 uv           : TEXCOORD0;
            float4 color        : COLOR;
        };

        struct Varyings {
            float4 positionCS   : SV_POSITION;
            float2 uv           : TEXCOORD0;
            float4 color        : COLOR;
            float3 normalWS     : NORMAL;
            float3 positionWS   : TEXCOORD1;
            float3 positionOS   : TEXCOORD2;
            float3 halfWayVec   : TEXCOORD3;//can remove if not work
            float4 shadowCoord  : TEXCOORD4;
        };

        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

		ENDHLSL

        Name "ForwardLit"
        Tags { "LightMode"="UniversalForward" }

        pass {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _SHADOWS_SOFT
            #pragma multi_compile _ _ADDITIONAL_LIGHTS_VERTEX _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile_fragment _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile _ MAIN_LIGHT_CALCULATE_SHADOWS
			#pragma multi_compile _ REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR

            Varyings vert(Attributes IN){
                Varyings OUT;

                VertexPositionInputs positionInputs = GetVertexPositionInputs(IN.positionOS.xyz);
                OUT.positionCS = positionInputs.positionCS;
                OUT.positionWS = positionInputs.positionWS;
                OUT.positionOS = IN.positionOS.xyz;
                OUT.color = IN.color;
                OUT.shadowCoord = GetShadowCoord(positionInputs);

                Light light = GetMainLight();
                OUT.halfWayVec = normalize(light.direction + normalize(GetWorldSpaceViewDir(OUT.positionWS)));
                //float3 forcedViewDir = GetCurrentViewPosition() - OUT.positionWS;
                //OUT.halfWayVec = normalize(light.direction + forcedViewDir); // light + view

                VertexNormalInputs normalInputs = GetVertexNormalInputs(IN.normalOS, IN.tangentOS);
                OUT.normalWS = normalInputs.normalWS;

                OUT.uv = TRANSFORM_TEX(IN.uv, _MainTex);
                // inv lerp => (t - a)/(b - a)
                //OUT.heightIrritation = (IN.positionOS.y - lowestPoint) / (lowestPoint - heighestPoint);

                return OUT;
            }

            float4 frag(Varyings IN) : SV_Target {
                
                // Shadows
                float4 shadowCoord;
                #if defined(REQUIRES_VERTEX_SHADOW_COORD_INTERPOLATOR)
                    shadowCoord = IN.shadowCoord;
                #elif defined(MAIN_LIGHT_CALCULATE_SHADOWS)
                    shadowCoord = TransformWorldToShadowCoord(float4(IN.positionWS,1));
                #elif defined(_MAIN_LIGHT_SHADOWS)
                    shadowCoord = input.shadowCoord;
                #else
                    shadowCoord = float4(0, 0, 0, 0);
                #endif
                
                #if defined(_MAIN_LIGHT_SHADOWS)
                    Light light = GetMainLight(shadowCoord);
                #else
                    Light light = GetMainLight();
                #endif
                // float4 shadowCoord = TransformWorldToShadowCoord(IN.positionWS);
                //half shadow = light.shadowAttenuation;
                half totalShadow = 1 - light.shadowAttenuation;
                
                // Main lighting
                //float diffComp = saturate(dot(light.direction, IN.normalWS) * _DiffuseCoef) * (1) * light.color;
                //float3 halfWayVec = normalize(GetWorldSpaceViewDir(IN.positionWS) + light.direction); // light + view
                float specComp = saturate(dot(normalize(IN.halfWayVec), normalize(IN.normalWS)));//try other spaces if it doesn't work
                specComp = pow(specComp, _SpecPower) * _SpecCoef;

                // Additional lighting //https://learnopengl.com/Lighting/Multiple-lights helpful !
                #ifdef _ADDITIONAL_LIGHTS
                    uint additionalLightsCount = GetAdditionalLightsCount();
                    for (uint i = 0; i < additionalLightsCount; i++){
                        Light extraLight = GetAdditionalLight(i, IN.positionWS);
                        half3 halfWayVec = normalize(normalize(extraLight.direction + GetWorldSpaceViewDir(IN.positionWS)));
                        specComp += pow(max(dot((halfWayVec), IN.normalWS) * ( extraLight.color * extraLight.distanceAttenuation),0), _SpecPower) * _SpecCoef;
                        #ifdef _ADDITIONAL_LIGHT_SHADOWS
                            totalShadow += (1 - extraLight.shadowAttenuation);
                        #endif
                    }
                    // totalShadow /= additionalLightsCount;
                #endif

                bool notInShadow = _UseShadows ? totalShadow < _ShadowThreshold : true;
                half goochLevel = min( (dot(light.direction, IN.normalWS) + 1) / 2, 0.99999); // maps [-1,1] to [0,1] of diffuse dot prod
                // goochLevel = 1 - goochLevel;
                // return float4(goochLevel,goochLevel,goochLevel,1);
                // half lightingPower = (ceil(goochLevel / (1/(float)_NbrShades)) - (notInShadow ? 0 : 1)) / _NbrShades;
                // half lightingPower = (1/(float)_NbrShades) * round(1 + ((goochLevel)/2) * _NbrShades);
                // half lightingPower = (1/(float)_NbrShades) + floor(goochLevel * _NbrShades) * (1/(float)_NbrShades);
                // half lightingPower = (floor(goochLevel * _NbrShades) + 1) * (1/(float)_NbrShades);
                half lightingPower = (floor(goochLevel * _NbrShades) + (notInShadow ? 1 : 0)) * (1/(float)_NbrShades);
                float4 toonShading = _BaseColor * (lightingPower) * SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, IN.uv);;
                toonShading = (specComp > _HighlightThreshold && notInShadow) ? _HighlightColor : toonShading;
                // return dot(light.direction, IN.normalWS) * light.shadowAttenuation * length(light.color) * light.distanceAttenuation; // testing lighting
                // return float4(lightingPower,lightingPower,lightingPower,1);
                return toonShading;
            }

            ENDHLSL
        }
        UsePass "Universal Render Pipeline/Lit/ShadowCaster"
        UsePass "Universal Render Pipeline/Lit/DepthOnly"
        UsePass "Universal Render Pipeline/Lit/Meta"
    }
}
