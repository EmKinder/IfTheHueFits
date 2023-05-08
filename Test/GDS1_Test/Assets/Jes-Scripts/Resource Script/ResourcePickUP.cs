using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePickUP : MonoBehaviour
{
    public int resource;
    public int Rr;
    public Text RrText;
    public int Yr;
    public Text YrText;
    public int Br;
    public Text BrText;
    public ItemClass redResource;
    InventoryManager inventory;

    void Start()
    {
        // inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
        Yr = 0;
        redResourceText();
        BlueResourceText();
        YellowResourceText();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();

    }



    public void AddResourceSystem(int pickup, ItemClass item)
    {
        resource = resource + pickup;

         inventory.Add(item, 1);
         Debug.Log(resource);
        

    }


   

    public void AddToRedResource(int redResourceScore)
    {
        Rr = Rr + redResourceScore;
       // inventory.Add(redResource, 1);
        RrText.text = Rr.ToString();
    }

    public void ResetRedResource()
    {
        Rr = 0;
        Yr = 0;
        Br = 0;
    }

    public void redResourceText() {
        RrText.text = Rr.ToString();
    }
    public void AddToYellowResource( int YellowResourceScore)
    {
        Yr = Yr + YellowResourceScore;
        YrText.text = Yr.ToString();
    }
    public void YellowResourceText()
    {
        YrText.text = Yr.ToString();
    }

    public void AddToBlueResource( int BlueResourceScore)
    {
        Br = Br + BlueResourceScore;
        BrText.text = Br.ToString();
    }

    public void BlueResourceText()
    {
        BrText.text = Br.ToString();
    }

}
