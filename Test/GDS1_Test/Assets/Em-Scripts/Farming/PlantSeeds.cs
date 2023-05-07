using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSeeds : MonoBehaviour
{
    InventoryManager inventory;
    bool canPlant;
    public GameObject growing;
    float timer;
    bool timerActive;
    bool plantGrown;
    public GameObject grown;
    string currentGrowingItemName;
    bool plantGrowing;

    //UI
    public Image timerUI;
    public Text timerText;
    public Text noResources;

    //Buttons
    public Button redFarmButton;
    public Button yellowFarmButton;
    public Button blueFarmButton;

    //Items
    public ItemClass redResource;
    public ItemClass yellowResource;
    public ItemClass blueResource;

    //Seeds
    public ItemClass redSeed;
    public ItemClass yellowSeed;
    public ItemClass blueSeed;

    //Materials
    public Material redMat;
    public Material yellowMat;
    public Material blueMat;

    // Start is called before the first frame update
    void Start()
    {

        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
        redFarmButton.gameObject.SetActive(false);
        yellowFarmButton.gameObject.SetActive(false);
        blueFarmButton.gameObject.SetActive(false);
        grown.SetActive(false);
        growing.SetActive(false);
        timerUI.gameObject.SetActive(false);
        canPlant = false;
        plantGrown = false;
        timerActive = false;
        plantGrowing = false;
        noResources.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timerUI.gameObject.SetActive(true);
            timer += Time.deltaTime;
            timerText.text = (30 - timer).ToString("f0");
            if(timer >= 30)
            {
                plantGrown = true;
                growing.SetActive(false);
                grown.SetActive(true);
                if(currentGrowingItemName == "Red")
                {
                    ChangeMaterial(grown, redMat);
                }
                if (currentGrowingItemName == "Yellow")
                {
                    ChangeMaterial(grown, yellowMat);
                }
                if (currentGrowingItemName == "Blue")
                {
                    ChangeMaterial(grown, blueMat);
                }
                timer = 0;
                timerActive = false;
                timerUI.gameObject.SetActive(false);
            }
        }
    }

    public bool EnoughSeeds(ItemClass item)
    {
        SlotClass temp = inventory.Contains(item);
        if(temp != null)
        {
            return true;
        }
        StopAllCoroutines();
        StartCoroutine(ResourceText());
        return false;
    }

    IEnumerator ResourceText()
    {
        noResources.enabled = true;
        yield return new WaitForSeconds(1.5f);
        noResources.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") {
            Debug.Log("Farmland stepped on");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Farming E Pressed");
                if (!plantGrowing)
                {
                    Debug.Log("Buttons Appear");
                    redFarmButton.gameObject.SetActive(true);
                    yellowFarmButton.gameObject.SetActive(true);
                    blueFarmButton.gameObject.SetActive(true);
                }
            }

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
            plantGrown = false;
                plantGrowing = false;
        
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (redFarmButton != null)
        {
            redFarmButton.gameObject.SetActive(false);
            yellowFarmButton.gameObject.SetActive(false);
            blueFarmButton.gameObject.SetActive(false);
        }
        canPlant = false;
    }

    public void PlantRed()
    {
        if (EnoughSeeds(redSeed))
        {
            plantGrowing = true;
            currentGrowingItemName = "Red";
            growing.SetActive(true);
            ChangeMaterial(growing, redMat);
            inventory.Remove(redSeed, 1);
            timerActive = true;
            canPlant = false;
            redFarmButton.gameObject.SetActive(false);
            yellowFarmButton.gameObject.SetActive(false);
            blueFarmButton.gameObject.SetActive(false);
        }

    }

    public void PlantYellow()
    {
        if (EnoughSeeds(yellowSeed))
        {
            plantGrowing = true;
            currentGrowingItemName = "Yellow";
            growing.SetActive(true);
            ChangeMaterial(growing, yellowMat);
            inventory.Remove(yellowSeed, 1);
            timerActive = true;
            canPlant = false;
            redFarmButton.gameObject.SetActive(false);
            yellowFarmButton.gameObject.SetActive(false);
            blueFarmButton.gameObject.SetActive(false);
        }
    }

    public void PlantBlue()
    {
        if (EnoughSeeds(blueSeed))
        {
            plantGrowing = true;
            currentGrowingItemName = "Blue";
            growing.SetActive(true);
            ChangeMaterial(growing, blueMat);
            inventory.Remove(blueSeed, 1);
            timerActive = true;
            canPlant = false;
            redFarmButton.gameObject.SetActive(false);
            yellowFarmButton.gameObject.SetActive(false);
            blueFarmButton.gameObject.SetActive(false);
        }
    }

    public void ChangeMaterial(GameObject gm, Material mat)
    {
        Renderer[] children;
        children = gm.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < 4; i++)
        {
            children[i].material = mat;
        }
    }
}
