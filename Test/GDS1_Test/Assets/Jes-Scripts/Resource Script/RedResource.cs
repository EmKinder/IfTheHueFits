using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedResource : MonoBehaviour
{
     public int pickup;
     public  ResourcePickUP resourcePickUP;
    public GameObject gem;
    public ItemClass redResource;

    private void Start()
    {
     //   resourcePickUP = GameObject.FindGameObjectWithTag("RedResource").GetComponent<ResourcePickUP>();
    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            resourcePickUP.AddResourceSystem(pickup, redResource);
            resourcePickUP.AddToRedResource(pickup);
           // Destroy(gem);
          //  Debug.Log(pickup);
        }
        else
        {

        }
    }
}
