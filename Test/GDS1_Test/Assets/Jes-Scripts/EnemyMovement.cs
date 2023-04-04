using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Transform playerTrans;
   
    Vector3 moveDirection;
    bool canMove;
    float currentCalmDown; //collision
    public Collider collisionDetect; //collision


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.GetComponent<Transform>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {  
        if (canMove)
        {
         
            Vector3 direction = playerTrans.position - transform.position;
            direction.Normalize();
            moveDirection = direction;
            transform.LookAt(playerTrans);
            transform.position += transform.forward * 1f * Time.deltaTime;
        }
      
          
       
    }

    public void SetCanMove(bool ifCanMove)
    {
        canMove = ifCanMove;

    }


    public void OnTriggerEnter(Collider other) //collision
    {
        if (other.tag == "Player")
        {
            
            currentCalmDown++;
            if (currentCalmDown > 0)
            {
                SetCanMove(false);
                Debug.Log("HIT");
                collisionDetect.enabled = false;
                StartCoroutine(waitforme());
                


            }
            



         



        }
    }
    IEnumerator waitforme() //collision
    {
        yield return new WaitForSeconds(4);
        SetCanMove(true);
        collisionDetect.enabled = true;
    }    
}

   
