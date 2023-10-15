using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCraftingTable : MonoBehaviour
{
    TriggerCraftingTable table;
    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.FindGameObjectWithTag("TriggerDesk").GetComponent<TriggerCraftingTable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseInventory()
    {
        table.CloseInventory();
    }
}
