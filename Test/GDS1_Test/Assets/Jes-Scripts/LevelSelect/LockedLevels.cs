using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedLevels : MonoBehaviour
{
    public Button[] buttonlevel;
    // Start is called before the first frame update
    void Start()
    {
        int currentPosition = PlayerPrefs.GetInt("Current", 4);
        for (int i = 0; i < buttonlevel.Length; i++)
        {
            if(i + 4 > currentPosition)
            {
                buttonlevel[i].interactable = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
