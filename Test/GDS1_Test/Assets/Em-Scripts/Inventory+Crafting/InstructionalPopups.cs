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
    [SerializeField] Image attackImage1;
    [SerializeField] Image attackImage2;
    [SerializeField] Image attackImage3;
    [SerializeField] Animator attackAnim1;
    [SerializeField] Animator attackAnim2;
    [SerializeField] Animator attackAnim3;
    [SerializeField] Text attackText1;
    [SerializeField] Text attackText2;
    [SerializeField] Text attackText3;
    int currentAttackAnim = 0;
    // [SerializeField] Animator cornerAnim;
   // [SerializeField] AnimationClip[] cornerAnimClips;
    int currentCornerAnim = 0;

    int currentSpeechInstruction = 0;
    Animator daveSpeakingAnim;
    Animation cornerAnimation;
    bool firstTimeAttack = false;

    bool firstRedCrafted = false;
    bool firstBlueCrafted = false;


    int currentUIPopup;

    InBowl ib;
    FirstResourcePickup firstResource;
    FirstHealthUI firstHealth;
    bool attackimages = false;

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
        attackImage1.enabled = false;
        attackImage2.enabled = false;
        attackImage3.enabled = false;
        attackText1.enabled = false;
        attackText2.enabled = false;
        attackText3.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("InBowl"))
        {
            ib = GameObject.FindGameObjectWithTag("InBowl").GetComponent<InBowl>();
            if (!firstRedCrafted) {
                firstRedCrafted = ib.firstRedPaint;
            }
            if (!firstBlueCrafted) { 
            firstBlueCrafted = ib.firstBluePaint;
             }

        }
        else
        {
            ib = null;
        }

        Debug.Log("Current Dialogue: " + currentSpeechInstruction);

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
            else if (attackimages)
            {
                if (currentAttackAnim == 0)
                {
                    attackAnim1.enabled = false;
                    attackImage1.color = new Color(1, 1, 1, 0.4f);
                    attackText1.enabled = false;
                    attackAnim2.enabled = true;
                    attackImage2.color = new Color(1, 1, 1, 1);
                    attackText2.enabled = true;
                    currentAttackAnim++;
                }
                else if (currentAttackAnim == 1)
                {
                    attackAnim2.enabled = false;
                    attackImage2.color = new Color(1, 1, 1, 0.4f);
                    attackText2.enabled = false;
                    attackAnim3.enabled = true;
                    attackImage3.color = new Color(1, 1, 1, 1);
                    attackText3.enabled = true;
                    currentAttackAnim++;
                }
                else if (currentAttackAnim == 2)
                {
                    Destroy(attackImage1.gameObject);
                    Destroy(attackImage2.gameObject);
                    Destroy(attackImage3.gameObject);
                    Destroy(attackText1.gameObject);
                    Destroy(attackText2.gameObject);
                    Destroy(attackText3.gameObject);
                    background.enabled = false;
                    attackimages = false;
                    Time.timeScale = 1;
                }
            }

            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {

                if (currentSpeechInstruction == 6 || currentSpeechInstruction == 7 || currentSpeechInstruction == 8)
                {
                    currentSpeechInstruction++;
                    DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                }
                else if (currentSpeechInstruction == 10 && speechBubbleSpritesComplete[10])
                {
                    CloseSpeechBubbleInstructions();
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                    currentSpeechInstruction++;
                }
                else if (currentSpeechInstruction == 9 && speechBubbleSpritesComplete[9] && !firstTimeAttack)
                {
                    CloseSpeechBubbleInstructions();
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                    DisplayAttackImages();
                    currentSpeechInstruction++;
                }
                else if (currentSpeechInstruction == 11 && speechBubbleSpritesComplete[11])
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
            
            if (firstRedCrafted && firstBlueCrafted)
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

    void DisplayAttackImages()
    {
        background.enabled = true;
        attackImage1.enabled = true;
        attackAnim1.enabled = true;
        attackText1.enabled = true;
        attackImage2.enabled = true;
        
        attackImage2.color = new Color(1, 1, 1, 0.4f);
        attackAnim2.enabled = false;
        attackImage3.enabled = true;

        attackAnim3.enabled = false;
        attackImage3.color = new Color(1, 1, 1, 0.4f);
        attackimages = true;
        firstTimeAttack = true;
        Time.timeScale = 0;
    }
}
