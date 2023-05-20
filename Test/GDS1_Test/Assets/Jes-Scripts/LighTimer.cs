using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighTimer : MonoBehaviour
{
    public float timerCounter;
    public bool timerCounterOn = false;
    private float tMinutes = 0;
    private float tSeconds = 0;
    private float tMSeconds = 0;
    Light lightobj;

    // Start is called before the first frame update
    void Start()
    {
        timerCounterOn = true;
        lightobj = GameObject.FindWithTag("theLight").GetComponent<Light>();;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerCounterOn)
        {
         
            Debug.Log(timerCounter);
            if (timerCounter >= 0)
            {
                lightobj.intensity = 1.0f;
                timerCounter = timerCounter + Time.deltaTime;
                timerCounter = timerCounter + 1 / 60;
              

                if(timerCounter >= 10 && timerCounter <= 15)
                {
                    lightobj.intensity = 0.0f;
                   // lightobj.enabled = false;
                 //   lightobj.color = new Color(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));

                }
                if(timerCounter > 15)
                {
                    timerCounter = 0;
                }
        
            }

        }
    }
}
