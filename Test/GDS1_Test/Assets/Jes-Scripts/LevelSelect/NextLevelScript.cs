using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelScript : MonoBehaviour
{
  public int sceneload;
    //int add;
    
    // Start is called before the first frame update
    void Start()
    {
       // add = 2;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void NextButton()
    {
       // add++;
        //SceneManager.LoadSceneAsync(add);
        sceneload = SceneManager.GetActiveScene().buildIndex +1;
        PlayerPrefs.SetInt("Current", sceneload);
        SceneManager.LoadScene("InventoryandCrafting");

      
       
    }

    public void CreditButton()
    {
        SceneManager.LoadScene("Credits");
    }

}
