using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowResource : MonoBehaviour
{
   public int pickup;
   public ResourcePickUP resourcePickUP;
    public GameObject gem;
    public ItemClass yellowResource;
    AudioSource audio;
    public AudioClip pickupSound;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("ResourceSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audio.clip = pickupSound;
            audio.Play();
            resourcePickUP.AddResourceSystem(pickup, yellowResource);
            // Destroy(gem);
            resourcePickUP.AddToYellowResource(pickup);
            Debug.Log(pickup);
        }
    }
}
