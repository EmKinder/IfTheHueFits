using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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
    float enemyHealth;
    float OriginalHealth;

    NavMeshAgent agent;
    public float wanderingTimer;
    public float wanderingRadius;
    float timer;
    LayerMask navLayerMask;
   public float lineOfSightRadius;
    bool canFollow;
    Transform savedPoint;
    public Canvas healthBarCanvas;
    public GameObject rotHealthBar;
    public Image healthBar;
    GameObject mainCamera;
    public Animator anim;

    float rangeTime = 4.0f;
    float rangeTimer = 0.0f;
    public GameObject paintball;
    public GameObject paintballPos;
    bool CanRangeAttack;

    public Material thisMat;


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
       // lineOfSightRadius = 0.5f;
        canFollow = false;
        navLayerMask = LayerMask.GetMask("Enemys", "Collectables");
        navLayerMask = ~navLayerMask;
        savedPoint = transform;

        if (gameObject.CompareTag("GreenHueman"))
        {
            enemyHealth = 10.0f;
        }
        else if (gameObject.CompareTag("OrangeHueman"))
        {
            enemyHealth = 20.0f;
        }
        else if (gameObject.CompareTag("YellowHueman"))
        {
            enemyHealth = 30.0f;
        }
        else if (gameObject.CompareTag("PurpleHueman"))
        {
            enemyHealth = 40.0f;
        }
        else if (gameObject.CompareTag("RedHueman"))
        {
            enemyHealth = 50.0f;
        }
        else if (gameObject.CompareTag("BlueHueman"))
        {
            enemyHealth = 60.0f;
        }
        OriginalHealth = enemyHealth;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        healthBarCanvas.worldCamera = Camera.main;
        healthBar.fillAmount = enemyHealth / OriginalHealth;

        if(this.gameObject.tag == "YellowHueman" || this.gameObject.tag == "BlueHueman" || this.gameObject.tag == "RedHueman")
        {
            CanRangeAttack = true;
            paintball.GetComponent<MeshRenderer>().material = thisMat;
        }
        else
        {
            CanRangeAttack = false;
        }
    }


    // Update is called once per frames
    void Update()
    {
        healthBar.fillAmount = enemyHealth / OriginalHealth;
        rotHealthBar.transform.LookAt(mainCamera.transform);
        if (canMove)
        {
            anim.SetBool("isWalking", true);
            if (!canFollow)
            {
                timer += Time.deltaTime;

                if (timer >= wanderingTimer)
                {
                    Vector3 newWander = NavigationArea(savedPoint.position, wanderingRadius, navLayerMask);
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
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (WithinRange() && CanRangeAttack)
        {
            rangeTimer += Time.deltaTime;
            if(rangeTimer >= rangeTime)
            {
                StartCoroutine(CanShootPaint());
              //  GameObject paintballClone = Instantiate(paintball, paintballPos.transform.position, this.transform.rotation);
                rangeTimer = 0.0f;
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
            anim.SetTrigger("isAttacking");
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

    public bool EnemyHealth(float hitDamage)
    {
        SetCanMove(false);
        canHitPlayer = false;
        enemyHealth -= hitDamage;
        StartCoroutine(damageDisplay());
        if (enemyHealth <= 0.0f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator damageDisplay()
    {
        yield return new WaitForSeconds(2);
        SetCanMove(true);
        canHitPlayer = true;
    }

    public void SetCured()
    {
        cured = true;
    }
    IEnumerator CanShootPaint()
    {
        anim.SetBool("isWalking", false);
        anim.SetTrigger("isAttacking");
        SetCanFollow(false);
        yield return new WaitForSeconds(2.0f);
        
        GameObject paintballClone = Instantiate(paintball, paintballPos.transform.position, this.transform.rotation);

        yield return new WaitForSeconds(0.5f);
        SetCanFollow(true);
        anim.SetBool("isWalking", true);
        Destroy(paintballClone, 1.5f);
    }
}


