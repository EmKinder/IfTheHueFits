using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedResource : MonoBehaviour
{
     public int pickup;
     public  ResourcePickUP resourcePickUP;
    public GameObject gem;
    public ItemClass redResource;
    AudioSource audio;
    public AudioClip pickupSound;

    private void Start()
    {
        //   resourcePickUP = GameObject.FindGameObjectWithTag("RedResource").GetComponent<ResourcePickUP>();
        audio = GameObject.FindGameObjectWithTag("ResourceSound").GetComponent<AudioSource>();
    }
    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.clip = pickupSound;
            audio.Play();
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
