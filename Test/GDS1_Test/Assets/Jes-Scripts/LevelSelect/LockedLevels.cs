using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedLevels : MonoBehaviour
{
    public Button[] buttonlevel;
    public int Current;
  //  public int currentPosition;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        //  currentPosition = 0;
      Current = 0;
       Current = PlayerPrefs.GetInt("Current", 1);
        for (int i = 0; i < buttonlevel.Length; i++)
        {
            if(i + 1 > Current)
            {
                buttonlevel[i].interactable = false;
            }
        }

      //  Debug.Log(Current);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
