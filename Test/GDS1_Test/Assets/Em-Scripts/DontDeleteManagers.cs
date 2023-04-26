using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDeleteManagers : MonoBehaviour
{
    // Start is called before the first frame update
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
