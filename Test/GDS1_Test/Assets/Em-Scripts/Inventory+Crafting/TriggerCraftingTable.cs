using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCraftingTable : MonoBehaviour
{

    private Canvas inventoryCanvas;
    public bool inventoryOpen;
    bool standingAtDesk;
    public Material emmisive;
    public Material normal;
    public GameObject desk;
    [SerializeField] GameObject craftingCanvas;
    GameObject thisCraftingCanvas;

    // Start is called before the first frame update
    void Start()
    {
      //  inventoryCanvas = GameObject.FindWithTag("InventoryCanvas").GetComponent<Canvas>();
      //  inventoryCanvas.enabled = false;
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
                thisCraftingCanvas = Instantiate(craftingCanvas);
             //   inventoryCanvas.enabled = true;
                inventoryOpen = true;

            }
            else if (inventoryOpen)
            {
                Debug.Log("Inventory close");
                Destroy(thisCraftingCanvas);
           //     inventoryCanvas.enabled = false;
                inventoryOpen = false;
            }
        }
        if (!standingAtDesk)
        {
            Destroy(thisCraftingCanvas);
            //  inventoryCanvas.enabled = false;
            inventoryOpen = false;
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
            desk.GetComponent<MeshRenderer>().material = emmisive;
            standingAtDesk = true;
            Debug.Log("Triggering Desk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            desk.GetComponent<MeshRenderer>().material = normal;
            standingAtDesk = false;
            //Debug.Log("Triggering Desk");
        }
    }
}
