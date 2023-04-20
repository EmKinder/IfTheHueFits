using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueResource : MonoBehaviour
{
   
        public int pickup;
        public ResourcePickUP resourcePickUP;
        public GameObject gem;
        public ItemClass blueResource;
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
            if (other.tag == "Player")
            {
                resourcePickUP.AddResourceSystem(pickup, blueResource);
                // Destroy(gem);
                resourcePickUP.AddToBlueResource(pickup);
                Debug.Log(pickup);
            }
        }
   
}
