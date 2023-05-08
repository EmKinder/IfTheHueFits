using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagingSceneChanges : MonoBehaviour
{
   Canvas InventoryCanvas;
  //  public Canvas LevelSelectCanvas;
  //  public Canvas JLevelSelectCanvas;
    private void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);
        


    }
    // Start is called before the first frame update
    void Start()
    {
        //  LevelSelectCanvas.enabled = false;
        //   JLevelSelectCanvas.enabled = false;
        InventoryCanvas = GameObject.FindGameObjectWithTag("InventoryCanvas").GetComponent<Canvas>();
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
        SceneManager.LoadScene("InventoryAndCrafting");
    }

    public void GoBackToCrafting()
    {
        SceneManager.LoadScene("InventoryAndCrafting");
    }

    public void FirstLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level1");
    }

    public void SecondLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level2");
    }

    public void ThirdLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level3");
    }
    public void ForthLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level4");
    }

    public void FifthLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level5");
    }

    public void SixthLevelLoad()
    {
        SceneManager.LoadScene("Jes-Level6");
    }

    public void LevelSelectLoad()
    {
        InventoryCanvas.enabled = false;
     //   LevelSelectCanvas.enabled = true;

         SceneManager.LoadScene("LevelSelect");
    }

    public void JaimiesLevelSelect()

    {
           InventoryCanvas.enabled = false;
          
        SceneManager.LoadScene("JLevelSelect");

    }

    public void returnbutton()
    {
   //   InventoryCanvas.enabled = false;
    //    JLevelSelectCanvas.enabled = false;
    //    LevelSelectCanvas.enabled = false;
    }
}
