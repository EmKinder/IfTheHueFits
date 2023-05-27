using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddle : MonoBehaviour
{
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            playerHealth.DealDamage(0.5f);

        }
    }
}
