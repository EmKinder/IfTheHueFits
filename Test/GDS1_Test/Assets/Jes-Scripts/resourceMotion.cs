using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceMotion : MonoBehaviour
{
    public int rotationSpeed = 100;
    private Vector3 scales;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float timing;
    bool canMove;
    // Start is called before the first frame update
    void Start()
    {
       
        canMove = false;
   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
       if(canMove == true)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime*2, transform.position.z);

        }
    }
        
    


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
          
            setcanMove(true);
           // StartCoroutine(waitforme());
        }
    }



    IEnumerator waitforme()
    {
        yield return new WaitForSeconds(1);
        setcanMove(true);

        
    }

    public void setcanMove(bool moveIt)
    {
        canMove = moveIt;
    }
}
