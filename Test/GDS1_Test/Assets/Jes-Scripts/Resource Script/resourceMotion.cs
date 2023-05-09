using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceMotion : MonoBehaviour
{
    public int rotationSpeed = 100;
    private Vector3 scales;
    bool canMove;
    bool canDisappear;
   
    // Start is called before the first frame update
    void Start()
    {
       
        canMove = false;
        canDisappear = false;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        if (canMove == true)
        {
            if (canDisappear == false)

                if(transform.position.y < 4f)
            {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime *10f, transform.position.z);
                    
                            }
            if (canDisappear == true)
            {
                gameObject.transform.localScale =  Vector3.Lerp(transform.localScale, scales, Time.deltaTime *10f);
            }

        }
    }
        
    


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
          
            setcanMove(true);
            StartCoroutine(waitforme());

        }
    }



    IEnumerator waitforme()
    {
        yield return new WaitForSeconds(0.3f);
        SetCanDisappear(true);

        
    }

    public void setcanMove(bool moveIt)
    {
        canMove = moveIt;
    }

    public void SetCanDisappear(bool disappear)
    {
        canDisappear = disappear;
    }
}

