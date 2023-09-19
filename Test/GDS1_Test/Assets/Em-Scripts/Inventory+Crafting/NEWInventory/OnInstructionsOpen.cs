using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnInstructionsOpen : MonoBehaviour, IPointerDownHandler
{
  //  [SerializeField] Button tableButton;
    [SerializeField] Image tableImage;
    [SerializeField] Image expandedImage;
    [SerializeField] GameObject openCol;
    [SerializeField] GameObject closeCol1;
    [SerializeField] GameObject closeCol2;
    [SerializeField] Image[] recipes;
    int toBeActivated;
    // Start is called before the first frame update
    void Start()
    {
        expandedImage.enabled = false;
        foreach(Image thisImage in expandedImage.GetComponentsInChildren<Image>())
        {
            thisImage.enabled = false;
        }
        closeCol1.SetActive(false);
        closeCol2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (PlayerPrefs.GetInt("Current") >= 4)
            OpenInstructions(3);
        else if (PlayerPrefs.GetInt("Current") >= 5)
            OpenInstructions(4);
        else if (PlayerPrefs.GetInt("Current") >= 6)
            OpenInstructions(6);
        else
            OpenInstructions(2);

    }

    public void OpenInstructions(int num)
    {
        //    tableButton.enabled = false;
        expandedImage.enabled = true;

        for (int i = 0; i < num; i++)
        {
            Debug.Log("Recipe should be showing");
            recipes[i].enabled = true;
        }
        tableImage.enabled = false;
        closeCol1.SetActive(true);
        closeCol2.SetActive(true);
        this.gameObject.SetActive(false);

    }
}
