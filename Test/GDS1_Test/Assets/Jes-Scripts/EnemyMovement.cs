using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    Transform playerTrans;
    //float speed = 2.0f;
    Vector3 moveDirection;
    bool canMove;
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
          // }
        }
    }

    public void SetCanMove(bool ifCanMove)
    {
        canMove = ifCanMove;

    }
    }

   
