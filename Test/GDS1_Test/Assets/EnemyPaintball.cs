using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaintball : MonoBehaviour
{
    Rigidbody rb;
    public float force = 0.000005f;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth.DealDamage(10.0f);
        }
    }
}
