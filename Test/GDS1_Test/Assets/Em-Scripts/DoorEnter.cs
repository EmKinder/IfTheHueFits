using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEnter : MonoBehaviour
{
    bool enterDoor;
  public  int add;
   // public Door door;
   int sceneload;
   //public NextLevelScript script;
    
   
    

    
    //  public int Current;
    // Start is called before the first frame update
    void Start()
    {
        enterDoor = false;
          add = 1;
     //   sceneload = 6;
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (enterDoor)
            {
                Debug.Log("Door Entered");
                                //  Debug.Log(add);
               //    sceneload = SceneManager.GetActiveScene().buildIndex + add;
                //    PlayerPrefs.SetInt("Current", sceneload);
                //   SceneManager.LoadScene(sceneload);
                //   PlayerPrefs.SetInt("Current", sceneload);
                //   SceneManager.GetSceneByBuildIndex(add +1);
                sceneload = PlayerPrefs.GetInt("Current", add);
                SceneManager.LoadScene(sceneload);
                //  SceneManager.LoadScene(scene)
                // PlayerPrefs.SetInt("Current", sceneload);
              //  SceneManager.LoadScene(script.sceneload +1);

                enterDoor = false;
                
            }
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            enterDoor = true;
            add++;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enterDoor = false;
         //   add = add + 1;
        }
    }


   
}
