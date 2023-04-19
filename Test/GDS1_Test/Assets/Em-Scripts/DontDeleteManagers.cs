using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDeleteManagers : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject sampleInstance;
    private void Awake()
    {
        if (sampleInstance != null)
            Destroy(sampleInstance);

        sampleInstance = gameObject;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
