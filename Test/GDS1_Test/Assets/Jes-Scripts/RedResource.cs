using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedResource : MonoBehaviour
{
   public int pickup;
   public ResourcePickUP resourcePickUP;
    public GameObject gem;
    public ItemClass redResource;
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            resourcePickUP.AddResourceSystem(pickup, redResource);
           // Destroy(gem);
          //  Debug.Log(pickup);
        }
    }
}
