using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEnter : MonoBehaviour
{
    bool enterDoor;
    int add = 1;
    public Door door;
    
   
    

    
    //  public int Current;
    // Start is called before the first frame update
    void Start()
    {
        enterDoor = false;
        //add++;
       
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (enterDoor)
            {
                Debug.Log("Door Entered");
               add++;
              //  Debug.Log(add);
               SceneManager.LoadSceneAsync(add);
                enterDoor = false;
                
            }
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            enterDoor = true;
          //  add++;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterDoor = false;
        }
    }


   
}
