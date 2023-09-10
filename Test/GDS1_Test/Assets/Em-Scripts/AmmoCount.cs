using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmmoCount : MonoBehaviour
{
    public int orangeAmmoCount;
    public int redAmmoCount;
    public int yellowAmmoCount;
    public int greenAmmoCount;
    public int blueAmmoCount;
    public int purpleAmmoCount;
    public NEWInventoryManager inventory;
    public ItemClass redAmmo;
    public ItemClass orangeAmmo;
    public ItemClass yellowAmmo;
    public ItemClass greenAmmo;
    public ItemClass blueAmmo;
    public ItemClass purpleAmmo;

    // Start is called before the first frame update
    void Start()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(14))
        {
            orangeAmmoCount = 100;
            redAmmoCount = 100;
            yellowAmmoCount = 100;
            greenAmmoCount = 100;
            blueAmmoCount = 100;
            purpleAmmoCount = 100;
        }
        else
        {
            orangeAmmoCount = 0;
            redAmmoCount = 0;
            yellowAmmoCount = 0;
            greenAmmoCount = 0;
            blueAmmoCount = 0;
            purpleAmmoCount = 0;
        }

     

    }

    // Update is called once per frame
    void Update()
    {
        if(inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<NEWInventoryManager>();
        }
    }

    public int getAmmoCount(string type)
    {
        if(type == "Red")
        {
            return redAmmoCount;
        }
        if (type == "Orange")
        {
            return orangeAmmoCount;
        }
        if (type == "Yellow")
        {
            return yellowAmmoCount;
        }
        if (type == "Green")
        {
            return greenAmmoCount;
        }
        if (type == "Blue")
        {
            return blueAmmoCount;
        }
        if (type == "Purple")
        {
            return purpleAmmoCount;
        }
        return 0;
    }

    public void addAmmoCount(string type, int quantity)
    {
        if (type == "Red")
        {
            redAmmoCount += quantity;
        }
        if (type == "Orange")
        {
             orangeAmmoCount += quantity;
        }
        if (type == "Yellow")
        {
             yellowAmmoCount += quantity;
        }
        if (type == "Green")
        {
             greenAmmoCount += quantity;
        }
        if (type == "Blue")
        {
             blueAmmoCount += quantity;
        }
        if (type == "Purple")
        {
             purpleAmmoCount += quantity;
        }

    }

    public void subAmmoCount(string type, int quantity)
    {
        if (type == "Red")
        {
            redAmmoCount -= quantity;
            if(inventory != null) { 
                inventory.RemoveItem(orangeAmmo, quantity);
            }

        }
        if (type == "Orange")
        {
            orangeAmmoCount -= quantity;
            inventory.RemoveItem(orangeAmmo, quantity);
        }
        if (type == "Yellow")
        {
            yellowAmmoCount -= quantity;
            inventory.RemoveItem(orangeAmmo, quantity);
        }
        if (type == "Green")
        {
            greenAmmoCount -= quantity;
            inventory.RemoveItem(orangeAmmo, quantity);
        }
        if (type == "Blue")
        {
            blueAmmoCount -= quantity;
            inventory.RemoveItem(orangeAmmo, quantity);
        }
        if (type == "Purple")
        {
            purpleAmmoCount -= quantity;
            inventory.RemoveItem(orangeAmmo, quantity);
        }

    }


}
