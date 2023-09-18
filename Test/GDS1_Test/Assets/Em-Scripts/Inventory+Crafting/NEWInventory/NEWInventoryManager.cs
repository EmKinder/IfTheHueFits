using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWInventoryManager : MonoBehaviour
{

    [SerializeField] public Dictionary<ItemClass, int> itemsInInventory = new Dictionary<ItemClass, int>();
    // Start is called before the first frame update
   [SerializeField] ItemClass redSeed;
   [SerializeField] ItemClass blueSeed;
    void Awake()
    {
        AddItem(redSeed, 2);
        AddItem(blueSeed, 2);
    }

    public void AddItem(ItemClass item, int quantity)
    {
        if (!itemsInInventory.ContainsKey(item))
        {
            itemsInInventory.Add(item, quantity);
            Debug.Log(quantity + "x " + item.ToString() + " added to inventory");
        }
        else
        {
            itemsInInventory[item] += quantity;
            Debug.Log(item.ToString() + "quantity increased");
        }
       
    }

    public void RemoveItem(ItemClass item, int quantity)
    {
        if (!itemsInInventory.ContainsKey(item))
        {
            return;
        }
        if(itemsInInventory[item] <= quantity)
        {
            itemsInInventory.Remove(item);
        }
        else
        {
            itemsInInventory[item] -= quantity;
        }
        Debug.Log(quantity + "x " + item.ToString() + " removed from inventory");
    }

    public int GetItemCount(ItemClass item)
    {
        if (itemsInInventory.ContainsKey(item)) 
            return itemsInInventory[item];

     //   Debug.Log("Not found");
        return 0;
    }

    public int BlueSeedAmount()
    {
        return itemsInInventory[blueSeed];
    }
}
