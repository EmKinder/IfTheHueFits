using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tumbleweed : MonoBehaviour
{
    PlayerHealth playerHealth;
    AudioSource audio;
    public AudioClip tumbleweedSound;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        audio = GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<AudioSource>();
      //  audio.clip = tumbleweedSound;
     //   audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector2.right, 20*(Time.deltaTime/60));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            playerHealth.DealDamage(0.5f);

        }
    }

}
