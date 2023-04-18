using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelScript : MonoBehaviour
{
  public  int sceneload;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneload = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButton()
    {
        
      
        if (sceneload > PlayerPrefs.GetInt("Current"))
        {
            PlayerPrefs.SetInt("Current", sceneload);
            Debug.Log(PlayerPrefs.GetInt("Current"));
        }
       SceneManager.LoadScene("LevelSelect");
      
       
    }
}
