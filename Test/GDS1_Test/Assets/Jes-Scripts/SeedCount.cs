using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeedCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int RedSeedCount;
    public int BlueSeedCount;
    public int YellowSeedCount;
    public NEWInventoryManager Inventory;
    public ItemClass YellowSeed;
    public ItemClass RedSeed;
    public ItemClass BlueSeed;
    public Text blueText;
    public Text redText;
    public Text yellowText;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        yellowS();
        blueS();
        redS();
    }

    public int getSeedCount(string type)
    {
        if (type == "RedSeed")
        {
            return RedSeedCount;
        }
        if(type == "BlueSeed")
        {
            return BlueSeedCount;
        }
        if(type == "YellowSeed")
        {
            return YellowSeedCount;
        }
        return 0;
    }


    public void addSeedCount(string type, int quantity)
    {
        if(type == "Red")
        {
            RedSeedCount += quantity; //amount being added each time. 
            redText.text = RedSeedCount.ToString();
        }
        if(type == "Blue")
        {
            BlueSeedCount += quantity;
            blueText.text = BlueSeedCount.ToString();
        }
        if(type == "Yellow")
        {
            YellowSeedCount += quantity;
            yellowText.text = YellowSeedCount.ToString();
        }
    }

    public void subSeedCount(string type, int quantity)
    {
        
        if (type == "Red")
        {
            RedSeedCount = RedSeedCount - quantity; //amount being taken away each time. 
       //     Inventory.Remove(RedSeed); //taking it away from the inventory scene. 
            redText.text = RedSeedCount.ToString();
        }
        if (type == "Blue")
        {
            BlueSeedCount = BlueSeedCount - quantity;
        //   Inventory.Remove(BlueSeed);
            blueText.text = BlueSeedCount.ToString();
        }
        if (type == "Yellow")
        {
            YellowSeedCount = YellowSeedCount - quantity;
        //    Inventory.Remove(YellowSeed);
            yellowText.text = YellowSeedCount.ToString();
        }
    }

    public void yellowS()
    {
        yellowText.text = YellowSeedCount.ToString();
    }

    public void blueS()
    {
        blueText.text = BlueSeedCount.ToString();
    }

    public void redS()
    {
        redText.text = RedSeedCount.ToString();
    }
}
