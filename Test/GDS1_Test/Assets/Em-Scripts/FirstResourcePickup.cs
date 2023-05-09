using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstResourcePickup : MonoBehaviour
{
    public Sprite resourceUI;
    Image image;
    bool firstTimeResource;

    // Start is called before the first frame update
    void Start()
    {
        firstTimeResource = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !firstTimeResource)
        {
            image = GameObject.FindGameObjectWithTag("InstructionalUI").GetComponent<Image>();
            image.enabled = true;
            image.sprite = resourceUI;
            firstTimeResource = true;
            Time.timeScale = 0;
        }
    }
}
