using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{

    public Animator doorLeft;
    public Animator doorRight;
    bool canDoorOpen;
    InstructionalPopups ip;
    // Start is called before the first frame update
    void Start()
    {
        ip = GameObject.FindGameObjectWithTag("IPPopup").GetComponent<InstructionalPopups>();
        canDoorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (ip.doorCanOpen == true)
            {
                canDoorOpen = true;
            }
        else
        {
            canDoorOpen = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && canDoorOpen)
        {


            doorLeft.SetTrigger("doorOpen");
            doorRight.SetTrigger("doorOpen");


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && canDoorOpen)
        {


            doorLeft.SetTrigger("doorClose");
            doorRight.SetTrigger("doorClose");


        }
    }

}
