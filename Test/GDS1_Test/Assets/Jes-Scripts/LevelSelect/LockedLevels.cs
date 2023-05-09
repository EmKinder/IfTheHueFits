using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LockedLevels : MonoBehaviour
{
    public Button[] buttonlevel;
    public Image[] images;
    public Button[] frames;
    public int Current;

  //  public int currentPosition;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
       Current = 0;
       Current = PlayerPrefs.GetInt("Current", 2);
        for (int i = 0; i < buttonlevel.Length; i++)
        {
            if (i > Current-2)
            {
                buttonlevel[i].interactable = false;
               
            }

        }
        for(int j = 0; j < images.Length; j++)
        {
            if (j > Current - 3)
            {
                images[j].enabled = true;
            }
            else
            {
                images[j].enabled = false;
            }
        }
        
    }

    // Update is called once per frame
   

    
    void Update()
    {
        
    }
}
