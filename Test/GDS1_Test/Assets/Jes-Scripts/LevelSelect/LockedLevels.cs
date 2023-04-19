using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LockedLevels : MonoBehaviour
{
    public Button[] buttonlevel;
    public int Current;
    public SceneManager scene;
  //  public int currentPosition;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
       Current = 0;
       Current = PlayerPrefs.GetInt("Current", 1);
        for (int i = 0; i < buttonlevel.Length; i++)
        {
            if(i  > Current -1)
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
