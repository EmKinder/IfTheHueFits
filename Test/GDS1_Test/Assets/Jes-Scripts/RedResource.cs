using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedResource : MonoBehaviour
{
   public int pickup;
   public ResourcePickUP resourcePickUP;
    public GameObject gem;
    public ItemClass redResource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            resourcePickUP.AddResourceSystem(pickup, redResource);
            Destroy(gem);
            Debug.Log(pickup);
        }
    }
}
