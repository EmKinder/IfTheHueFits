using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
  // public  GameObject me;
  //  Rigidbody body;
    float calmDown = 5;
    float currentCalmDown;
    Transform playertrans;
    GameObject player;
    //bool allowAttack;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        //  player = GameObject.FindGameObjectWithTag("Player");
        //  allowAttack = true;
        
        player = GameObject.FindGameObjectWithTag("Player");
        playertrans = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            if (currentCalmDown > 0)
            {
                currentCalmDown = calmDown;
                Debug.Log("HIT");
                //body.transform.fre;
               // Invoke("boo", 5);

            }
            


         //   body.freezeRotation = false;



        }

        
    }
  //  void boo()
 //   {
   //     body.freezeRotation = true;
  //  }


}
