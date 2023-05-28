using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForJaimesLevel : MonoBehaviour
{
    private static GameObject sampleInstance;
    private bool jaimesLevel;
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

// Start is called before the first frame update
    void Start()
        {
        
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBool(bool clicked)
    {
        jaimesLevel = clicked;
    }

    public bool GetBool()
    {
        return jaimesLevel;
    }
}
