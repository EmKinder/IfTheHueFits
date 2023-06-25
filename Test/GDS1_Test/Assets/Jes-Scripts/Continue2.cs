using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue2 : MonoBehaviour
{
    
    int Continuing;
    public Image blankedOut;
     int  countingArrays;
    bool appear;
    // Start is called before the first frame update
    void Start()
    {
        // Continuing = 0;
        if (PlayerPrefs.GetInt("Continuing", 0) <= 0)
        {
            blankedOut.enabled = true;
            PlayerPrefs.SetInt("Continuing", 1);
            
           
        }
        else
        {
            blankedOut.enabled = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
