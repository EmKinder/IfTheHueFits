using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagingSceneChanges : MonoBehaviour
{
    //  Canvas InventoryCanvas;
    //  public Canvas LevelSelectCanvas;
    //  public Canvas JLevelSelectCanvas;

  
    CheckForJaimesLevel jaime;
    private void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);


    }
    // Start is called before the first frame update
    void Start()
    {
        //  LevelSelectCanvas.enabled = false;
        //   JLevelSelectCanvas.enabled = false;
        //    InventoryCanvas = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();

        jaime = GameObject.FindGameObjectWithTag("Jaime").GetComponent<CheckForJaimesLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restartlevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void PauseLevel()
    {
        Time.timeScale = 0f;
        
    }

    public void ResumeLevel()
    {
        Time.timeScale = 1f;
    }

    public void ExitScene()
    {
        Time.timeScale = 1f;
        //   SceneManager.LoadScene("InventoryAndCrafting");
        SceneManager.LoadScene("MainMenu");
    }

    public void GoBackToCrafting()
    {
        SceneManager.LoadScene("InventoryAndCrafting");
    }

    public void FirstLevelLoad()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SecondLevelLoad()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ThirdLevelLoad()
    {
        SceneManager.LoadScene("Level3");
    }
    public void ForthLevelLoad()
    {
        SceneManager.LoadScene("Level4");
    }

    public void FifthLevelLoad()
    {
        SceneManager.LoadScene("Level5");
    }

    public void SixthLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level6");
    }

    public void LevelSelectLoad()
    {
       // InventoryCanvas.enabled = false;
     //   LevelSelectCanvas.enabled = true;

         SceneManager.LoadScene("LevelSelect");
    }

    public void JaimiesLevelSelect()

    {
        //  InventoryCanvas.enabled = false;
       SceneManager.LoadScene("JLevelSelect");

    }

    public void JaimiesInventory()
    {
        jaime.SetBool(true);
        SceneManager.LoadScene("InventoryAndCrafting");
    }

    public void returnbutton()
    {
   //   InventoryCanvas.enabled = false;
    //    JLevelSelectCanvas.enabled = false;
    //    LevelSelectCanvas.enabled = false;
    }

    public void newGame()
    {
        PlayerPrefs.DeleteAll();
        jaime.SetGameRestartBool(true);
        jaime.SetBool(false);
        SceneManager.LoadScene("InventoryAndCrafting");
    }
}
