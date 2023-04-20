using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSeeds : MonoBehaviour
{
    InventoryManager inventory;
    public SlotClass[] inputItems;
    bool canPlant;
    GameObject redFarmButton;
    GameObject yellowFarmButton;
    GameObject blueFarmButton;
    public GameObject growing;
    float timer;
    bool timerActive;
    bool plantGrown;
    GameObject grown;
    ItemClass redResource;
    ItemClass yellowResource;
    ItemClass blueResource;
    string currentGrowingItemName;

    // Start is called before the first frame update
    void Start()
    {
        redFarmButton = GameObject.FindGameObjectWithTag("RedFarmButton");
        yellowFarmButton = GameObject.FindGameObjectWithTag("YellowFarmButton");
        blueFarmButton = GameObject.FindGameObjectWithTag("BlueFarmButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            if(timer >= 30)
            {
                plantGrown = true;
                growing.SetActive(false);
                grown.SetActive(true);
                timer = 0;
                timerActive = false;
            }
        }
    }

    public bool EnoughSeeds(InventoryManager inventory)
    {
        if (inventory.isFull())
        {
            return false;
        }
        for (int i = 0; i < inputItems.Length; i++)
        {
            if (!inventory.Contains(inputItems[i].GetItem(), inputItems[i].GetQuantity()))
            {
                return false;
            }
        }
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !canPlant)
        {
            if(redFarmButton != null)
            {
                redFarmButton.SetActive(true);
                yellowFarmButton.SetActive(true);
                blueFarmButton.SetActive(true);
            }
            canPlant = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && canPlant)
        {
            if (redFarmButton != null)
            {
                redFarmButton.SetActive(false);
                yellowFarmButton.SetActive(false);
                blueFarmButton.SetActive(false);
            }
            canPlant = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && plantGrown)
        {
            if(currentGrowingItemName == "Red")
            {
                inventory.Add(redResource, 4);
            }
            if (currentGrowingItemName == "Yellow")
            {
                inventory.Add(yellowResource, 4);
            }
            if (currentGrowingItemName == "Blue")
            {
                inventory.Add(blueResource, 4);
            }

            grown.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (redFarmButton != null)
        {
            redFarmButton.SetActive(false);
            yellowFarmButton.SetActive(false);
            blueFarmButton.SetActive(false);
        }
        canPlant = false;
    }

    public void PlantRed()
    {
        if (canPlant && !timerActive)
        {
            if (EnoughSeeds(inventory))
            {
                currentGrowingItemName = "Red";
                growing.SetActive(true);
                inventory.Remove(redResource, 1);
                timerActive = true;
                canPlant = false;
            }
        }
    }

    public void PlantYellow()
    {
        if (canPlant && !timerActive)
        {
            if (EnoughSeeds(inventory))
            {
                currentGrowingItemName = "Yellow";
                growing.SetActive(true);
                inventory.Remove(yellowResource, 1);
                timerActive = true;
                canPlant = false;
            }
        }

    }

    public void PlantBlue()
    {
        if (canPlant && !timerActive)
        {
            if (EnoughSeeds(inventory))
            {
                currentGrowingItemName = "Blue";
                growing.SetActive(true);
                inventory.Remove(blueResource, 1);
                timerActive = true;
                canPlant = false;
            }
        }

    }
}
