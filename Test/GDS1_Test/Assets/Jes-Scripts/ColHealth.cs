using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColHealth : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerHealth playerHealth;
    Animator CTrigger;
    GameObject col;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        col = GameObject.FindWithTag("COL");
        CTrigger = col.GetComponent<Animator>();
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
