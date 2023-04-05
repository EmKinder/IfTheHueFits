using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePickUP : MonoBehaviour
{
    public int resource;
    InventoryManager inventory;

   

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddResourceSystem(int pickup, ItemClass item)
    {
        resource = resource + pickup;
        //addtoInventory()
            inventory.Add(item, 1);


    }


    public void addToInventory()
    {
        /*need to use resource here to make them add up. In the previous game we did I had placed a
        
         void ScoreText(){
        textScore.text = score.ToString();
        } 

        then placed the ScoreText() into the Start(). 

        However im not to sure how it would work with the inventory.
        */

    }
}
