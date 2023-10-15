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
    Material deskMat;

    // Start is called before the first frame update
    void Start()
    {
        inventoryOpen = false;
        deskMat = desk.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) && !inventoryOpen)
        {
            if (standingAtDesk && !inventoryOpen)
            {
                thisCraftingCanvas = Instantiate(craftingCanvas);
                inventoryOpen = true;

            }
            else if (inventoryOpen)
            {
                Destroy(thisCraftingCanvas);
                inventoryOpen = false;
            }
        }
        if (!standingAtDesk || Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            deskMat = emmisive;
            standingAtDesk = true;
            Debug.Log("Triggering Desk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deskMat = normal;
            standingAtDesk = false;
        }
    }

    public void CloseInventory()
    {
        Destroy(thisCraftingCanvas);
        inventoryOpen = false;
    }
}
