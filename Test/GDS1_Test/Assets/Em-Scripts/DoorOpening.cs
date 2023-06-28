using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{

    public Animator doorLeft;
    public Animator doorRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {


            doorLeft.SetTrigger("doorOpen");
            doorRight.SetTrigger("doorOpen");


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {


            doorLeft.SetTrigger("doorClose");
            doorRight.SetTrigger("doorClose");


        }
    }
}
