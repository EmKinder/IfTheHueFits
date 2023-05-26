using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighTimer : MonoBehaviour
{
    public float timerCounter;
    public bool timerCounterOn = false;
    Light lightobj;
   // public Canvas imagecanvas;

    // Start is called before the first frame update
    void Start()
    {
        timerCounterOn = true;
        lightobj = GameObject.FindWithTag("theLight").GetComponent<Light>();;
     //   imagecanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerCounterOn)
        {
         
            Debug.Log(timerCounter);
            if (timerCounter >= 0)
            {
             //   imagecanvas.enabled = false;
                  lightobj.intensity = 1.0f;
                timerCounter = timerCounter + Time.deltaTime;
                timerCounter = timerCounter + 1 / 60;
              

                if(timerCounter >= 10 && timerCounter <= 15)
                {
                  //  imagecanvas.enabled = true;
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
