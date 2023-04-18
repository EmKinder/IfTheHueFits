using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagingSceneChanges : MonoBehaviour
{

    private void Awake()
    {
       // DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
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

}
