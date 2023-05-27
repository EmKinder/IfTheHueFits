using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddle : MonoBehaviour
{
    PlayerHealth playerHealth;
   public Collider puddlePaint; 

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
     //   puddlePaint = GetComponent<Collider>();

        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            //   playerHealth.DealDamage(0.5f);

            playerHealth.DealHealth(20f);
            puddlePaint.isTrigger = false;

        }
    }
}
