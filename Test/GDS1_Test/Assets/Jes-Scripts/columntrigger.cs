using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columntrigger : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    Animator CTrigger;
    GameObject col;
    Collider collid;
    bool timerCounterOn = false;
    float timerCounter;
    bool hasfallen = false;
    void Start()
    {
        col = GameObject.FindWithTag("COL");
        CTrigger = col.GetComponent<Animator>();
        collid = col.GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {
        if(hasfallen == true)
        if (timerCounterOn == true)
        {

            Debug.Log(timerCounter);
            if (timerCounter >= 0)
            {

                timerCounter = timerCounter + Time.deltaTime;
                timerCounter = timerCounter + 1 / 60;


                if (timerCounter >= 0 && timerCounter <= 1)
                {
                    playerHealth.DealDamage(5.0f);

                }
                if (timerCounter > 1)
                {
                    timerCounterOn = false;
                        collid.isTrigger = false;
                }

            }

        }
        
        if(hasfallen == false)
         {
            timerCounterOn = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CTrigger.SetTrigger("Fall");
            timerCounterOn = true;
            hasfallen = true;
            

        }
    }
}
