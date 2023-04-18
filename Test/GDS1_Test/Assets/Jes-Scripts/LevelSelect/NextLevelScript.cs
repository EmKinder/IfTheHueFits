using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelScript : MonoBehaviour
{
  public int sceneload;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButton()
    {

        sceneload = SceneManager.GetActiveScene().buildIndex +1;
        if (sceneload > PlayerPrefs.GetInt("Current"))
        {
            PlayerPrefs.SetInt("Current", sceneload);
          
        }
       SceneManager.LoadScene("LevelSelect");
      
       
    }
}
