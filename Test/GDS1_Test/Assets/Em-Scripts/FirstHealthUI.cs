using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstHealthUI : MonoBehaviour
{
    public Sprite resourceUI;
    Image image;
    bool firstTimeHealth;

    // Start is called before the first frame update
    void Start()
    {
        firstTimeHealth = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !firstTimeHealth)
        {
            image = GameObject.FindGameObjectWithTag("InstructionalUI").GetComponent<Image>();
            image.enabled = true;
            image.sprite = resourceUI;
            firstTimeHealth = true;
            Time.timeScale = 0;
        }
    }
}
