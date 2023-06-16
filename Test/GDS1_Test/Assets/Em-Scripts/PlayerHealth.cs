using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float playerHealth;
    Rigidbody player;
  //  Input inputmanager;
    CharacterMovement moving;
    
  
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100.0f;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        moving = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
       // inputmanager = GetComponent<Input>();
        
        // anim.Play("StandingReactDeathBackward");
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
     //   if(playerHealth <= 0)
     //   {
      //      StartCoroutine(waitforme());
      //      SceneManager.LoadScene("GameOver");
      //  }
    }

    public void DealDamage(float damage)
    {
        playerHealth -= damage;
        healthBar.fillAmount = playerHealth / 100;
        
    }

  

    public void CheckHealth()
    {
        if(playerHealth <= 0)
        {
            Debug.Log("Game Over");

             
            anim.Play("StandingReactDeathBackward");

            // player.constraints = RigidbodyConstraints.FreezePosition;
            //  player.velocity = Vector3.zero;
            //  if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            //    {
           // moving.PlayerMovementRegular();
            moving.enabled = false;
            //    }
            // RigidbodyConstraints.FreezePositionX = true;

            player.isKinematic = true;
            Invoke("GameOver", 5);
            
             // StartCoroutine(waitforme());
           //  SceneManager.LoadScene("GameOver");
        }
    }

    public void DealHealth(float health)
    {
        playerHealth += health;
        healthBar.fillAmount = playerHealth / 100;

    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }



}
