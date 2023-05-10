using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEnter : MonoBehaviour
{
    bool enterDoor;
  public  int add;
    Canvas canvas;
   // public Door door;
   int sceneload;
    //public NextLevelScript script;
    public Material emmisive;
    public Material normal;
    public GameObject door;

    private void Awake()
    {
        // enterDoor = true;
        canvas = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
    }



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
                canvas.enabled = false;
                sceneload = PlayerPrefs.GetInt("Current", add);
                SceneManager.LoadScene(sceneload);
                enterDoor = false;
                
            }
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            door.GetComponent<MeshRenderer>().material = emmisive;
            enterDoor = true;
            add++;
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            door.GetComponent<MeshRenderer>().material = normal;
            enterDoor = false;
         //   add = add + 1;
        }
    }


   
}
