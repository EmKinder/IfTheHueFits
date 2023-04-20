using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class curehuemanpause : MonoBehaviour
{
    GameObject tutCanvas;


    // Start is called before the first frame update
    void Start()
    {
        tutCanvas = this.gameObject;
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnterButtonFunction()
    {
        Time.timeScale = 1.0f;
        tutCanvas.SetActive(false);
    }

    
}
