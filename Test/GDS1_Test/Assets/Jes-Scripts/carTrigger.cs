using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carTrigger : MonoBehaviour
{
    PlayerHealth playerHealth;
   
    public GameObject col;
    public float Y;
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
        if (other.tag == "Wall")
        {
            col.transform.Rotate(0f, 0f, 0f);
           
        }
    }
}
