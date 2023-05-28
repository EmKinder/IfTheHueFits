using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleWeedLevel5 : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody car1;
    float carSpeed = 2.5f;
    // PlayerHealth playerHealth;
    public GameObject Mcar;
    Collider collid;
    bool moving = false;
    void Start()
    {
        // Mcar = GameObject.FindWithTag("Car");

        collid = Mcar.GetComponent<Collider>();
        car1 = Mcar.GetComponent<Rigidbody>();

        //  playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();



    }

    // Update is called once per frame
    void Update()
    {
        if (moving == true)
        {

            car1.velocity = Mcar.transform.forward * carSpeed;

        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            moving = true;
            // playerHealth.DealDamage(5.0f);
        }

    }

}
