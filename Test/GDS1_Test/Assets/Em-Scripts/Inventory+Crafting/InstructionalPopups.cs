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
    [SerializeField] Image cornerImage1;
    [SerializeField] Image cornerImage2;
    [SerializeField] Image cornerImage3;
   // [SerializeField] Animator cornerAnim;
   // [SerializeField] AnimationClip[] cornerAnimClips;
    int currentCornerAnim = 0;

    int currentSpeechInstruction = 0;
    Animator daveSpeakingAnim;
    Animation cornerAnimation;


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
        //cornerAnim = cornerImage.gameObject.GetComponent<Animator>();
        cornerImage1.enabled = false;
        cornerImage2.enabled = false;
        cornerImage3.enabled = false;

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

            else if (currentSpeechInstruction == 1 || currentSpeechInstruction == 2 || currentSpeechInstruction == 4) 
            {
                CloseSpeechBubbleInstructions();
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                currentSpeechInstruction++;
                //currentSpeechInstruction++;
            }
            else if (currentSpeechInstruction == 5 && speechBubbleSpritesComplete[currentSpeechInstruction] == true)
            {
                CloseSpeechBubbleInstructions();
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                currentSpeechInstruction++;
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
            if(GameObject.FindGameObjectWithTag("InBowl").GetComponent<InBowl>() != null) { 
                ib = GameObject.FindGameObjectWithTag("InBowl").GetComponent<InBowl>();
            }
            else
            {
                ib = null;
            }
            if (ib.firstRedPaint && ib.firstBluePaint && ib!= null)
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

        if(currentSpeechInstruction == 2 && currentCornerAnim == 0)
        {
            cornerImage1.enabled = true;
            //cornerAnim.Play(cornerAnimClips[0].ToString());
            //cornerAnim.SetBool("isWASD", true);
           
            //cornerAnimation.Play();
        }
        if(currentCornerAnim == 1)
        {
            cornerImage2.enabled = true;
            //  cornerAnim.Play(cornerAnimClips[1].ToString());
           // cornerAnim.SetBool("isPlant", true);
        }
        if(currentSpeechInstruction == 3 && currentCornerAnim == 2)
        {
            cornerImage3.enabled = true;
            //  cornerAnim.Play(cornerAnimClips[2].ToString());
         //   cornerAnim.SetBool("isHarvest", true);
        }

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && currentCornerAnim == 0)
        {
            Destroy(cornerImage1.gameObject);
            currentCornerAnim++;
        }
        if((ps1.triggeredFirstTime || ps2.triggeredFirstTime || ps3.triggeredFirstTime || ps4.triggeredFirstTime || ps5.triggeredFirstTime) && currentCornerAnim == 1)
        {
            Destroy(cornerImage2.gameObject);
            // cornerAnim.SetBool("isPlant", false);
            currentCornerAnim++;
        }

        if ((ps1.plantHarvested || ps2.plantHarvested || ps3.plantHarvested || ps4.plantHarvested || ps5.plantHarvested) && currentCornerAnim == 2)
        {
            Destroy(cornerImage3.gameObject);

            //  cornerAnim.SetBool("isHarvest", false);
            currentCornerAnim++;
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
