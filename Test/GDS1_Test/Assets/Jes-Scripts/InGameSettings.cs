using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InGameSettings : MonoBehaviour
{
    ManagingSceneChanges scene;
    public Canvas SettingsIcon;
    public Canvas gameSettings;
    public Button RB;
    public Button BB;
    public Button Paused;
    public bool GamePaused;
    private void Awake()
    {
        gameSettings.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameSettings.enabled = false;
        if (Paused == true)
        {
            GamePuased(true);
            SettingsButton();
            RestartButton();
            backButton();
        }
        {

        }
       
      //  RestartButton();
     //   backButton();
    }


    public void SettingsButton()
    {
        if(Paused == true)
        {
            gameSettings.enabled = true;
           scene.PauseLevel();
            
        }
    }

    public void RestartButton()
    {
        if(RB == true)
        {
            scene.Restartlevel(); 
        }
    }

    public void backButton()
    {
        if(BB == true)
        {
            gameSettings.enabled = false;
            scene.Restartlevel();
            GamePuased(false);

        }
    }

    public void GamePuased(bool gameisPaused)
    {
        GamePaused = gameisPaused;
    }
    
}
