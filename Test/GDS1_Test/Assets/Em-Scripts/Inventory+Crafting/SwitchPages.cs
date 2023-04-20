using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPages : MonoBehaviour
{
    public Button button;
    GameObject redPage;
    GameObject orangePage;
    GameObject yellowPage;
    GameObject greenPage;
    GameObject bluePage;
    GameObject purplePage;
    GameObject coverPage;
    // Start is called before the first frame update
    void Start()
    {
      //  button.onClick.AddListener(OnButtonClick);

        redPage = GameObject.FindGameObjectWithTag("RedPage");
        orangePage = GameObject.FindGameObjectWithTag("OrangePage");
        yellowPage = GameObject.FindGameObjectWithTag("YellowPage");
        greenPage = GameObject.FindGameObjectWithTag("GreenPage");
        bluePage = GameObject.FindGameObjectWithTag("BluePage");
        purplePage = GameObject.FindGameObjectWithTag("PurplePage");
        coverPage = GameObject.FindGameObjectWithTag("CoverPage");

        redPage.SetActive(false);
        orangePage.SetActive(false);
        yellowPage.SetActive(false);
        greenPage.SetActive(false);
        bluePage.SetActive(false);
        purplePage.SetActive(false);
        coverPage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoverForward()
    {
        coverPage.SetActive(false);
        redPage.SetActive(true);
    }
    public void RedBack()
        {
            coverPage.SetActive(true);
        redPage.SetActive(false);
    }

    public void RedForward()
    {
        redPage.SetActive(false);
        yellowPage.SetActive(true);
    }

    public void YellowBack()
    {
        redPage.SetActive(true);
        yellowPage.SetActive(false);
    }

    public void YellowForward()
    {
        yellowPage.SetActive(false);
        bluePage.SetActive(true);
    }

    public void BlueBack()
    {
        bluePage.SetActive(false);
        yellowPage.SetActive(true);
    }

    public void BlueForward()
    {
        bluePage.SetActive(false);
        orangePage.SetActive(true);
    }

    public void OrangeBack()
        {
        bluePage.SetActive(true);
        orangePage.SetActive(false);
    }

    public void OrangeForward()
    {
        greenPage.SetActive(true);
        orangePage.SetActive(false);
    }

    public void GreenBack()
    {
        greenPage.SetActive(false);
        orangePage.SetActive(true);
    }

    public void GreenForward()
    {
        greenPage.SetActive(false);
        purplePage.SetActive(true);
    }

    public void PurpleBack()
    {
        greenPage.SetActive(true);
        purplePage.SetActive(false);

    }
}
