using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider VSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void VolChange()
    {
        AudioListener.volume = VSlider.value;
        VSaved();
    }

    public void VSaved()
    {
        PlayerPrefs.SetFloat("VMusic", VSlider.value);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
