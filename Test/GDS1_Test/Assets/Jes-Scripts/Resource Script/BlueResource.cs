using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlueResource : MonoBehaviour
{
   
        public int pickup;
        public ResourcePickUP resourcePickUP;
        public GameObject gem;
        public ItemClass blueResource;
    AudioSource audio;
    public AudioClip pickupSound;
   // public int sceneload;
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
            if (other.tag == "Player")
            {
            audio.clip = pickupSound;
            audio.Play();
            resourcePickUP.AddResourceSystem(pickup, blueResource);
                // Destroy(gem);
                resourcePickUP.AddToBlueResource(pickup);
                Debug.Log(pickup);
             //   SceneManager.LoadScene("WinScene");
            }
        }



}
