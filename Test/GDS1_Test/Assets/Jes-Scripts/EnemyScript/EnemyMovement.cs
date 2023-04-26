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
    Transform patrolPointOrigin;
    float wanderingTimer;
    public float wanderingRadius;
    private float timer;
    LayerMask navLayerMask;
    float lineOfSightRadius;
    bool canFollow;

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
        agent = this.GetComponent<NavMeshAgent>();
        timer = wanderingTimer;
        lineOfSightRadius = 15.0f;
        canFollow = false;
    }

    private void Awake()
    {
        patrolPointOrigin = this.transform;
        navLayerMask = LayerMask.GetMask("Enemys", "Collectables");
        navLayerMask = ~navLayerMask;
    }


    // Update is called once per frames
    void Update()
    {  
        if(canMove)
        {
            while (!canFollow)
            {
                timer += Time.deltaTime;

                if (timer >= wanderingTimer)
                {
                    patrolPointOrigin.position = this.transform.position;
                    Vector3 newWander = NavigationArea(patrolPointOrigin.position, wanderingRadius, navLayerMask);
                    agent.SetDestination(newWander);
                    timer = 0;
                }

                LineOfSight(lineOfSightRadius);

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
                    patrolPointOrigin.position = this.transform.position;
                }

            }
        }
      
          
       
    }
    
    public static Vector3 NavigationArea(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void LineOfSight(float maxDistrance)
    {
        RaycastHit hit;
        Vector3 rayDirection = player.transform.position - this.transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, maxDistrance, navLayerMask))
        {
            if(hit.transform == player.transform)
            {
                SetCanFollow(true);
            }
        }
    }

    public bool WithinRange()
    {
        float playerEscapeDistance = Vector3.Distance(player.transform.position, this.transform.position);
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

   
