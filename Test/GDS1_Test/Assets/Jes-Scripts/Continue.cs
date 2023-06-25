using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Continue : MonoBehaviour
{
    public int loading;
   
    
    
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

    public void nextScene()
    {
        // add++;
        //SceneManager.LoadSceneAsync(add);
        loading = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("Continue", loading);
        SceneManager.LoadScene("MainMenu");

    }


    }
