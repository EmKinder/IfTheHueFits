using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnInstructionsClose : MonoBehaviour, IPointerDownHandler
{
    //  [SerializeField] Button tableButton;
    [SerializeField] Image tableImage;
    [SerializeField] Image expandedImage;
    [SerializeField] GameObject openCol;
    [SerializeField] GameObject closeCol1;
    [SerializeField] GameObject closeCol2;
    [SerializeField] Image[] recipes;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (PlayerPrefs.GetInt("Current") == 4)
            CloseInstructions(3);
        else if (PlayerPrefs.GetInt("Current") == 5)
            CloseInstructions(4);
        else if (PlayerPrefs.GetInt("Current") == 6)
            CloseInstructions(6);
        else
            CloseInstructions(2);
    }

    public void CloseInstructions(int num)
    {
        //    tableButton.enabled = false;
        

       for(int i = 0; i < num; i++)
        {
            recipes[i].enabled = false;
        }
        expandedImage.enabled = false;
        tableImage.enabled = true;
        openCol.SetActive(true);
        closeCol1.SetActive(false);
        closeCol2.SetActive(false);


    }
}
