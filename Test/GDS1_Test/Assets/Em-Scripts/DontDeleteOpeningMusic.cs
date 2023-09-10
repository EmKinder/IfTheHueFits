using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDeleteOpeningMusic : MonoBehaviour
{
    private static GameObject sampleInstance;
    void Awake()
    {
        //check that this instance exists
        if (sampleInstance == null)
        {
            //if it doesnt, make it exist
            sampleInstance = this.gameObject;
        }
        else if (sampleInstance != this)
        {
            //destroy duplicate instances
            Destroy(gameObject);
        }
        //set this instance as protected
        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(gameObject);
        }
    }
}
