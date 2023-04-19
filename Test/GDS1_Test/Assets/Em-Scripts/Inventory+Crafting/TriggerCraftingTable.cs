using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCraftingTable : MonoBehaviour
{

    public Canvas inventoryCanvas;
    bool inventoryOpen;
    bool standingAtDesk;

    // Start is called before the first frame update
    void Start()
    {
   //     inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        inventoryCanvas.enabled = false;
        inventoryOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            if (standingAtDesk && !inventoryOpen)
            {
                Debug.Log("Inventory open");
                inventoryCanvas.enabled = true;
                inventoryOpen = true;

            }
            else if (inventoryOpen)
            {
                Debug.Log("Inventory close");
                inventoryCanvas.enabled = false;
                inventoryOpen = false;
            }
        }
            
           /* else if (inventoryOpen)
            {
                Debug.Log("Inventory close");
                inventoryCanvas.enabled = false;
                inventoryOpen = false;
            }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            standingAtDesk = true;
            Debug.Log("Triggering Desk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            standingAtDesk = false;
            //Debug.Log("Triggering Desk");
        }
    }
}
