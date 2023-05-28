using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class columntrigger : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    Animator CTrigger;
    public GameObject col;
    Collider collid;
    bool timerCounterOn = false;
    float timerCounter;
    bool hasfallen = false;
    AudioSource audio;
    public AudioClip fallingSound;
    
    void Start()
    {
       // col = GameObject.FindWithTag("COL");
        CTrigger = col.GetComponent<Animator>();
        collid = col.GetComponent<Collider>();
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        audio = GameObject.FindGameObjectWithTag("ColumnSound").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasfallen == true)
        {
            if (timerCounterOn == true)
            {

                Debug.Log(timerCounter);
                if (timerCounter >= 0)
                {

                    timerCounter = timerCounter + Time.deltaTime;
                    timerCounter = timerCounter + 1 / 60;


                    if (timerCounter >= 0 && timerCounter <= 0.01)
                    {
                        playerHealth.DealDamage(5.0f);

                    }
                    if (timerCounter > 0.01)
                    {
                        timerCounterOn = false;
                        collid.isTrigger = false;
                    }

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
            if (!hasfallen)
            {
                audio.clip = fallingSound;
                audio.Play();
            }
            CTrigger.SetTrigger("Fall");
            timerCounterOn = true;
            hasfallen = true;
            

        }
        
    }
}
