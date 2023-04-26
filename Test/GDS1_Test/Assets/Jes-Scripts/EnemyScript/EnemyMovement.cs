using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Transform playerTrans;
   
    bool canMove;
    float currentCalmDown; //collision
    public Collider collisionDetect; //collision
    bool cured;
    bool canHitPlayer;
    PlayerHealth playerHealth;

    NavMeshAgent agent;
    public float wanderingTimer;
    public float wanderingRadius;
    float timer;
    LayerMask navLayerMask;
    float lineOfSightRadius;
    bool canFollow;
    Transform savedPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrans = player.GetComponent<Transform>();
        canMove = true;
        canMove = true;
        cured = false;
        canHitPlayer = true;
        playerHealth = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<PlayerHealth>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        wanderingTimer = Random.Range(2.0f, 5.0f);
        timer = wanderingTimer;
        lineOfSightRadius = 15.0f;
        canFollow = false;
        navLayerMask = LayerMask.GetMask("Enemys", "Collectables");
        navLayerMask = ~navLayerMask;
        savedPoint = transform;
    }


    // Update is called once per frames
    void Update()
    {  
        if(canMove)
        {
            if(!canFollow)
            {
                timer += Time.deltaTime;

                if (timer >= wanderingTimer)
                {
                    Debug.Log("SavedPosition = " + savedPoint.position);
                    Vector3 newWander = NavigationArea(savedPoint.position, wanderingRadius, navLayerMask);
                    Debug.Log("New Wander Position = " + newWander);
                    agent.SetDestination(newWander);
                    timer = 0;
                }

                LineOfSight();

            }



            if (canFollow)
            {
                if (WithinRange())
                {
                    agent.SetDestination(playerTrans.position);
                }
                else
                {
                    SetCanFollow(false);
                }

            }
        }
      
          
       
    }
    
    public Vector3 NavigationArea(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist + origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void LineOfSight()
    {


        if (Vector3.Distance(player.transform.position, transform.position) <= lineOfSightRadius)
        {
            SetCanFollow(true);
            Debug.Log("Player in Sight of " + gameObject.name.ToString());

        }
    }

    public bool WithinRange()
    {
        float playerEscapeDistance = Vector3.Distance(player.transform.position, transform.position);
        if (playerEscapeDistance > lineOfSightRadius * 2)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetCanFollow(bool ifCanFollow)
    {
        canFollow = ifCanFollow;

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

   
