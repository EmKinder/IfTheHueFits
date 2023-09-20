using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InstructionalPopupsLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
  //  public NextLevelScript nextLevelScript;
   // CheckForJaimesLevel jaime;


    //public TriggerCraftingTable ct;
   // public InventoryManager im;
  //  public SwitchPages sp;

    [SerializeField] Image daveImage;
    [SerializeField] Image speechBubbleImage;
    [SerializeField] Image topCornerAnimations;
    [SerializeField] Image background;

    bool[] speechBubbleSpritesComplete;
    [SerializeField] Text spaceToCloseText;
    [SerializeField] Sprite[] speechBubbleSprites;
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

    int currentSpeechInstruction = 0;
    Animator daveSpeakingAnim;
    bool firstTimeAttack = false;

    int currentUIPopup;

    InBowl ib;

    bool attackimages = false;

    [SerializeField] FirstResourcePickup firstResource;
    [SerializeField] FirstHealthUI firstHealth;

    void Start()
    {
       // jaime = GameObject.FindGameObjectWithTag("Jaime").GetComponent<CheckForJaimesLevel>();
        daveSpeakingAnim = daveImage.gameObject.GetComponent<Animator>();
        daveSpeakingAnim.enabled = false;

        speechBubbleSpritesComplete = new bool[speechBubbleSprites.Length];
        for (int i = 0; i < speechBubbleSpritesComplete.Length; i++)
            speechBubbleSpritesComplete[i] = false;


        //speechBubbleImage.sprite = speechBubbleSprites[currentSpeechInstruction];
        if (PlayerPrefs.GetInt("Current") < 3)
        {
            DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
        }
        else
        {
            CloseSpeechBubbleInstructions();
        }
        //cornerAnim = cornerImage.gameObject.GetComponent<Animator>();
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
        if (PlayerPrefs.GetInt("Current") < 3)
        {

            // if (jaime.GetGameRestartBool() == true)
            //  {
            //      ResetUI();
            //      jaime.SetGameRestartBool(false);
            // }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (currentSpeechInstruction == 0 || currentSpeechInstruction == 1 || currentSpeechInstruction == 2)
                {
                    currentSpeechInstruction++;
                    DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                }
                else if (currentSpeechInstruction == 4 && speechBubbleSpritesComplete[4])
                {
                    CloseSpeechBubbleInstructions();
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                    currentSpeechInstruction++;
                }
                else if (currentSpeechInstruction == 3 && speechBubbleSpritesComplete[3] && !firstTimeAttack)
                {
                    CloseSpeechBubbleInstructions();
                    speechBubbleSpritesComplete[currentSpeechInstruction] = true;
                    DisplayAttackImages();
                    currentSpeechInstruction++;
                }
                else if (currentSpeechInstruction == 5 && speechBubbleSpritesComplete[5])
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






            }

            if (currentSpeechInstruction == 0)
            {
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }
            else if (firstResource.firstTimeResource && currentSpeechInstruction == 4)
            {
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }
            else if (firstHealth.firstTimeHealth && currentSpeechInstruction == 5)
            {
                Debug.Log("Current Speech Instruction: " + currentSpeechInstruction);
                DisplaySpeechBubbleInstructions(speechBubbleSprites[currentSpeechInstruction]);
                speechBubbleSpritesComplete[currentSpeechInstruction] = true;
            }

            Debug.Log("Current speech instruct: " + currentSpeechInstruction);
            Debug.Log("Resource triggered: " + firstResource.firstTimeResource);
            Debug.Log("Health triggered: " + firstHealth.firstTimeHealth);

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
