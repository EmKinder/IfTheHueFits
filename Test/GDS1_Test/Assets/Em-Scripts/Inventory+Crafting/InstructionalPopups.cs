using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionalPopups : MonoBehaviour
{
    // Start is called before the first frame update
    public NextLevelScript nextLevelScript;
    public PlantSeeds ps1;
    public PlantSeeds ps2;
    public PlantSeeds ps3;
    public PlantSeeds ps4;
    public PlantSeeds ps5;

    public TriggerCraftingTable ct;
    public InventoryManager im;

    public Image image;
    bool instructionsOpen;
    bool firstPlantHasBeenGrown;
    bool inventoryOpenFirstTime;
    bool firstPlantHasBeenHarvested;
    bool firstTimeRedCrafted;
    bool firstTimeBlueCrafted;
    bool firstTimePurpleCrafted;
    bool complementaryTutorialFinished;
    bool firstLevelOpen;
    bool firstResourceSeen;
    bool firstLevelComplete;
    bool secondLevelComplete;
    bool thirdLevelComplete;

    public Sprite plantingUI;
    public Sprite grownUI;
    public Sprite inventoryUI;
    public Sprite redPaintUI;
    public Sprite bluePaintUI;
    public Sprite complementaryUI;
    public Sprite doorUI;
    public Sprite controlsUI;
    public Sprite purpleUI;
    public Sprite varietyUI;
    public Sprite yellowUI;
    public Sprite orangeGreenUI;

    int currentUIPopup;

    void Start()
    {
        firstPlantHasBeenHarvested = false;
        firstPlantHasBeenGrown = false;
        firstLevelOpen = false;
        complementaryTutorialFinished = false;
        firstLevelComplete = false;
        secondLevelComplete = false;
        thirdLevelComplete = false;
        firstTimePurpleCrafted = false;
        image.sprite = plantingUI;
        Time.timeScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (complementaryTutorialFinished)
            {
                image.enabled = true;
                image.sprite = doorUI;
                Time.timeScale = 0;


            }
            else
            {
                image.enabled = false;
                Time.timeScale = 1;
            }
            complementaryTutorialFinished = false;
        }

        if((ps1.plantGrown || ps2.plantGrown || ps3.plantGrown || ps4.plantGrown || ps5.plantGrown) && !firstPlantHasBeenGrown)
        {
           
            firstPlantHasBeenGrown = true;
            image.enabled = true;
            image.sprite = grownUI;
            Time.timeScale = 0;
        }

        if ((ps1.plantHarvested || ps2.plantHarvested || ps3.plantHarvested || ps4.plantHarvested || ps5.plantHarvested) && !firstPlantHasBeenHarvested)
        {

            firstPlantHasBeenHarvested = true;
            image.enabled = true;
            image.sprite = inventoryUI;
            Time.timeScale = 0;
        }

        if (!inventoryOpenFirstTime && ct.inventoryOpen)
        {
            inventoryOpenFirstTime = true;
            image.enabled = true;
            image.sprite = redPaintUI;
            Time.timeScale = 0;
        }

        if (!firstTimeRedCrafted && im.redCrafted)
        {
            firstTimeRedCrafted = true;
            image.enabled = true;
            image.sprite = bluePaintUI;
            Time.timeScale = 0;
        }

        if(!firstTimeBlueCrafted && im.blueCrafted)
        {
            complementaryTutorialFinished = true;
            firstTimeBlueCrafted = true;
            image.enabled = true;
            image.sprite = complementaryUI;
            Time.timeScale = 0;
        }

        if(SceneManager.GetActiveScene().buildIndex == 2 && !firstLevelOpen)
        {
            firstLevelOpen = true;
            image.enabled = true;
            image.sprite = controlsUI;
            Time.timeScale = 0;
        }

        if(SceneManager.GetActiveScene().buildIndex == 0 && !firstLevelComplete && PlayerPrefs.GetInt("Current") == 3)
        {
                firstLevelComplete = true;
                image.enabled = true;
                image.sprite = purpleUI;
                Time.timeScale = 0;
        }

        if (!firstTimePurpleCrafted && im.purpleCrafted && PlayerPrefs.GetInt("Current") == 3)
        {
            firstTimePurpleCrafted = true;
            image.enabled = true;
            image.sprite = varietyUI;
            Time.timeScale = 0;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0 && !secondLevelComplete && PlayerPrefs.GetInt("Current") == 4)
        {
            secondLevelComplete = true;
            image.enabled = true;
            image.sprite = yellowUI;
            Time.timeScale = 0;
        }

        if (SceneManager.GetActiveScene().buildIndex == 0 && !thirdLevelComplete && PlayerPrefs.GetInt("Current") == 5)
        {
            thirdLevelComplete = true;
            image.enabled = true;
            image.sprite = orangeGreenUI;
            Time.timeScale = 0;
        }
    }
}
