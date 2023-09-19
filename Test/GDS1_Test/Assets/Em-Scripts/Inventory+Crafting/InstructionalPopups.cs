using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionalPopups : MonoBehaviour
{
    // Start is called before the first frame update
    public NextLevelScript nextLevelScript;
    CheckForJaimesLevel jaime;

    public bool doorCanOpen = false;
    public PlantSeeds ps1;
    public PlantSeeds ps2;
    public PlantSeeds ps3;
    public PlantSeeds ps4;
    public PlantSeeds ps5;

    public TriggerCraftingTable ct;
    public InventoryManager im;
    public SwitchPages sp;

    [SerializeField] Image daveImage;
    [SerializeField] Image speechBubbleImage;
    [SerializeField] Image topCornerAnimations;
    [SerializeField] Image background;

    bool[] speechBubbleSpritesComplete;
    [SerializeField] Text spaceToCloseText;
    [SerializeField] Sprite[] speechBubbleSprites;

    int currentSpeechInstruction = 0;
    Animator daveSpeakingAnim;


    int currentUIPopup;

    InBowl ib;
    FirstResourcePickup firstResource;
    FirstHealthUI firstHealth;

    void Start()
    {
        jaime = GameObject.FindGameObjectWithTag("Jaime").GetComponent<CheckForJaimesLevel>();
        daveSpeakingAnim = daveImage.gameObject.GetComponent<Animator>();
        daveSpeakingAnim.enabled = false;

        speechBubbleSpritesComplete = new bool[speechBubbleSprites.Length];
        for (int i = 0; i < speechBubbleSpritesComplete.Length; i++)
            speechBubbleSpritesComplete[i] = false;

        //speechBubbleImage.sprite = speechBubbleSprites[currentSpeechInstruction];
        DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
    }

    // Update is called once per frame
    void Update()
    {

        if (jaime.GetGameRestartBool() == true)
        {
            ResetUI();
            jaime.SetGameRestartBool(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentSpeechInstruction == 0 || (currentSpeechInstruction == 3 && ct.inventoryOpen))
            {
                currentSpeechInstruction++;
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }

            else if (currentSpeechInstruction == 1 || currentSpeechInstruction == 2 || currentSpeechInstruction == 4 || currentSpeechInstruction == 5) 
            {
                CloseSpeechBubbleInstructions();
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                currentSpeechInstruction++;
                //currentSpeechInstruction++;
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {

                if (currentSpeechInstruction == 6 || currentSpeechInstruction == 7 || currentSpeechInstruction == 8)
                {
                    currentSpeechInstruction++;
                    DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                }
                else if(currentSpeechInstruction == 9 || currentSpeechInstruction == 10)
                {
                    CloseSpeechBubbleInstructions();
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                    currentSpeechInstruction++;
                }
                else if (currentSpeechInstruction == 11)
                {
                    CloseSpeechBubbleInstructions();
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                    currentSpeechInstruction++;
                }
            }

        }

        if ((ps1.plantGrown || ps2.plantGrown || ps3.plantGrown || ps4.plantGrown || ps5.plantGrown) && currentSpeechInstruction == 2)
        {
            Debug.Log("HARVEST SPEECH BUBBLE SHOULD BE APPEARING");
            DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
            speechBubbleSpritesComplete[currentSpeechInstruction] = true;

        }

        if (ct.inventoryOpen && currentSpeechInstruction == 3)
        {
            DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
            speechBubbleSpritesComplete[currentSpeechInstruction] = true;
        }

        if (currentSpeechInstruction == 5)
        {
            ib = GameObject.FindGameObjectWithTag("InBowl").GetComponent<InBowl>();
            if (ib.firstRedPaint && ib.firstBluePaint)
            {
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                doorCanOpen = true;
            }

        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            firstResource = GameObject.FindGameObjectWithTag("FirstResourceTrigger").GetComponent<FirstResourcePickup>();
            firstHealth = GameObject.FindGameObjectWithTag("FirstHealthTrigger").GetComponent<FirstHealthUI>();
            if (currentSpeechInstruction == 6)
            {
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }
            else if (firstResource.firstTimeResource && currentSpeechInstruction == 10)
            {
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }
            else if (firstHealth.firstTimeHealth && currentSpeechInstruction == 11)
            {
                Debug.Log("Current Speech Instruction: " + currentSpeechInstruction);
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }
        }
    }

    void DisplaySpeechBubbleInstructions(Sprite thisSprite)
    {
        background.enabled = true;
        daveImage.enabled = true;
        speechBubbleImage.enabled = true;
        speechBubbleImage.sprite = thisSprite;
        spaceToCloseText.enabled = true;
        Debug.Log(currentSpeechInstruction);
        daveSpeakingAnim.enabled = true;
        Time.timeScale = 0;


    }

    void CloseSpeechBubbleInstructions()
    {
        background.enabled = false;
        daveImage.enabled = false;
        speechBubbleImage.enabled = false;
        spaceToCloseText.enabled = false;
        daveSpeakingAnim.enabled = false;
        Time.timeScale = 1;
    }

    void DisplayControlsInstructions(Sprite thisSprite)
    {
        //anim play stuff
    }

    void ResetUI()
    {
        currentSpeechInstruction = 0;
        for (int i = 0; i < speechBubbleSpritesComplete.Length; i++)
            speechBubbleSpritesComplete[i] = false;
    }
}
