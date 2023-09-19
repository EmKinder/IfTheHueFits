using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnInventoryOpen : MonoBehaviour
{
    NEWInventoryManager inventory;
    
    [SerializeField] Image redPot;
    [SerializeField] Image bluePot;
    [SerializeField] Image yellowPot;
    [SerializeField] Image selectableItems;
    [SerializeField] ItemClass redFlower;
    [SerializeField] ItemClass blueFlower;
    [SerializeField] ItemClass yellowFlower;
    Image thisPot;
    ItemClass thisItemClass;
    Image[] pots;
    ItemClass[] items;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<NEWInventoryManager>();
        pots = new Image[3];
        pots[0] = redPot;
        pots[1] = yellowPot;
        pots[2] = bluePot;
        items = new ItemClass[3];
        items[0] = redFlower;
        items[1] = yellowFlower;
        items[2] = blueFlower;
        FillPots();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBackToPots(string colour)
    {
        ItemClass itemToAdd = null;
        Image potToAddToo = null;
        if(colour == "Red")
        {
            itemToAdd = redFlower;
            potToAddToo = pots[0];
        }
        else if(colour == "Yellow")
        {
            itemToAdd = yellowFlower;
            potToAddToo = pots[1];
        }
        else if(colour == "Blue")
        {
            itemToAdd = blueFlower;
            potToAddToo = pots[2];
        }

        if (itemToAdd != null && potToAddToo != null)
        {
            Vector3 thisPosition = new Vector3(potToAddToo.transform.position.x + Random.Range(-20, 20),
                                                       potToAddToo.transform.position.y + Random.Range(-20, 20),
                                                       potToAddToo.transform.position.z);
            Image si = Instantiate(selectableItems, thisPosition, Quaternion.identity) as Image;
            si.gameObject.name = itemToAdd.name + "SelectableItem";
            si.sprite = itemToAdd.itemCraftingIcon;
            si.transform.parent = gameObject.transform;
            si.transform.Rotate(0, 0, Random.Range(0, 360));
            si.transform.localScale = new Vector3(2, 2, 2);
            si.GetComponent<InventoryPickup>().SetThisItem(itemToAdd);
        }

    } 

    public void FillPots()
    {
        Debug.Log("Fill Pots Called");
        for (int k = 0; k < 3; k++)
        {
            thisPot = pots[k];
            thisItemClass = items[k];
           // Debug.Log(thisPot);
            if (inventory.GetItemCount(thisItemClass) > 0)
            {
                for (int i = 0; i < inventory.GetItemCount(thisItemClass); i++)
                {
                    Vector3 thisPosition = new Vector3(thisPot.transform.position.x + Random.Range(-20, 20),
                                                   thisPot.transform.position.y + Random.Range(-20, 20),
                                                   thisPot.transform.position.z);
                    Image si = Instantiate(selectableItems, thisPosition, Quaternion.identity) as Image;
                    si.gameObject.name = thisItemClass.name + "SelectableItem";
                    si.sprite = thisItemClass.itemCraftingIcon;
                    si.transform.parent = gameObject.transform;
                    si.transform.Rotate(0, 0, Random.Range(0, 360));
                    si.transform.localScale = new Vector3(2, 2, 2);
                    si.GetComponent<InventoryPickup>().SetThisItem(thisItemClass);
                }
            }
        }
    }
}
