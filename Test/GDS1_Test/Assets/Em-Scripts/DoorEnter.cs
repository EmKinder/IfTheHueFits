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
   // public GameObject door;
    CheckForJaimesLevel jaime;
    public Animator doorLeft;
    public Animator doorRight;
    InstructionalPopups ip;
    bool canDoorOpen;

    private void Awake()
    {
        // enterDoor = true;
        
        canvas = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
        
    }



    //  public int Current;
    // Start is called before the first frame update
    void Start()
    {
        ip = GameObject.FindGameObjectWithTag("IPPopup").GetComponent<InstructionalPopups>();
        enterDoor = false;
        canDoorOpen = false;
        //  add = 1;
        //   sceneload = 6;
        jaime = GameObject.FindGameObjectWithTag("Jaime").GetComponent<CheckForJaimesLevel>();
      //  doorLeft.anima
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        //  {
            if (ip.firstTimeBlueCrafted == true)
            {
                canDoorOpen = true;
            }
            else
            {
            canDoorOpen = false;
        
            }
        if (enterDoor && canDoorOpen)
            {

            Debug.Log(ip.firstTimeBlueCrafted == true);
                Debug.Log("Door Entered");
                canvas.enabled = false;
                // sceneload = PlayerPrefs.GetInt("Current", add);
                // SceneManager.LoadScene(sceneload);
                if (!jaime.GetBool())
                {
                    SceneManager.LoadScene("LevelSelect");
                }
                else
                {
                    SceneManager.LoadScene("JLevelSelect");
                }
               
                enterDoor = false;
                
            }
     //   }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collisiondetected");
        if(other.tag == "Player" )
        {
            Debug.Log("playercollisiondetected");
            enterDoor = true; 
         /*   doorLeft.SetTrigger("doorOpen");
            doorRight.SetTrigger("doorOpen"); */


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            enterDoor = false;
          /*  doorLeft.SetTrigger("doorClose");
            doorRight.SetTrigger("doorClose"); */


        }
    }


   
}
