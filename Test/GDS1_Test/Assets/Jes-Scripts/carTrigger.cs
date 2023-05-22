using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carTrigger : MonoBehaviour
{
    PlayerHealth playerHealth;
   
    //GameObject col;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        //col = GameObject.FindWithTag("Car");
       
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth.DealDamage(5.0f);

        }

    }
}
