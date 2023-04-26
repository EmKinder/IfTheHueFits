using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Transform playerTrans;
   
    Vector3 moveDirection;
    bool canMove;
    float currentCalmDown; //collision
    public Collider collisionDetect; //collision
    bool cured;
    bool canHitPlayer;
    PlayerHealth playerHealth;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.GetComponent<Transform>();
        canMove = true;
        cured = false;
        canHitPlayer = true;
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        agent = this.GetComponent<NavMeshAgent>();
    }


    // Update is called once per frames
    void Update()
    {  
        if (canMove)
        {
            /*
               Vector3 direction = playerTrans.position - transform.position;
               direction.Normalize();
               moveDirection = direction;
               float distance = Vector3.Distance(transform.position, player.transform.position);
               // Debug.Log(distance);


               if (distance < 15.0f)
               {
                   transform.LookAt(playerTrans);
                   transform.position += transform.forward * 3f * Time.deltaTime;
               }

               */

            agent.SetDestination(playerTrans.position);


          
        }
      
          
       
    }

    public void SetCanMove(bool ifCanMove)
    {
        canMove = ifCanMove;

    }


    public void OnTriggerEnter(Collider other) //collision
    {
        if (other.tag == "Player" && !cured && canHitPlayer)
        {
            playerHealth.DealDamage(10.0f);
            currentCalmDown++;
            if (currentCalmDown > 0)
            {
                SetCanMove(false);
                
                canHitPlayer = false;
                StartCoroutine(waitforme());

            }
        }
    }
    IEnumerator waitforme() //collision
    {
        yield return new WaitForSeconds(4);
        SetCanMove(true);
        canHitPlayer = true;
    }    

    public void SetCured()
    {
        cured = true;
    }

}

   
