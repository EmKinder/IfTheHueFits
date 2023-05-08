using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InGameSettings : MonoBehaviour
{
   public  ManagingSceneChanges scene;
    public Canvas SettingsIcon;
    public Canvas gameSettings;
    public Button RB;
    public Button BB;
    public Button EB;
    public Button Paused;
    public static bool GamePaused = false;
   // CharacterMovement movement;
    private void Awake()
    {
        gameSettings.enabled = false;
      // movement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
      //  movement.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
       // GamePaused = false;
     /*   Button resetB = RB.GetComponent<Button>();
        resetB.onClick.AddListener(RestartButton);
        Button backB = BB.GetComponent<Button>();
        backB.onClick.AddListener(backButton);
        Button pausedB = Paused.GetComponent<Button>();
        pausedB.onClick.AddListener(SettingsButton);
     */
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SettingsButton()
    {
        if(Paused == true)
        {
            gameSettings.enabled = true;
           scene.PauseLevel();
     //      movement.enabled = false;
            
        }
    }

    public void RestartButton()
    {
        if(RB == true)
        {
            gameSettings.enabled = false;
            scene.Restartlevel();
       //     movement.enabled = true;
        }
    }

    public void backButton()
    {
        if(BB == true)
        {
            gameSettings.enabled = false;
            scene.ResumeLevel();
            GamePuased(false);
        //    movement.enabled = true;

        }
    }


    public void ExitButton()
    {
        gameSettings.enabled = false;
        scene.ExitScene();
       // if (movement != null)
      ////  {
       //     movement.enabled = true;
       // }
    }

    public void GamePuased(bool gameisPaused)
    {
        GamePaused = gameisPaused;
    }
    
}
