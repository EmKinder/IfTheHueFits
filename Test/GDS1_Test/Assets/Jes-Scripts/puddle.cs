using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddle : MonoBehaviour
{
    PlayerHealth playerHealth;
   public GameObject puddlePaint;
    AudioSource audio;
    public AudioClip puddleSound;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        audio = GameObject.FindGameObjectWithTag("PuddleSound").GetComponent<AudioSource>();
     //   puddlePaint = GetComponent<Collider>();

        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            //   playerHealth.DealDamage(0.5f);
            audio.clip = puddleSound;
            audio.Play();
            playerHealth.DealHealth(20f);
            Destroy(puddlePaint);
        }
    }
}
