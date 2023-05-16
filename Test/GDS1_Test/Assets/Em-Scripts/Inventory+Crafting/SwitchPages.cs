using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPages : MonoBehaviour
{
    public Button button;
    public GameObject redPage;
    public GameObject orangePage;
    public GameObject yellowPage;
    public GameObject greenPage;
    public GameObject bluePage;
    public GameObject purplePage;
    public GameObject coverPage;

    public Image purpleLock;
    public Image yellowLock;
    public Image orangeLock;
    public Image greenLock;

    string currentPage;

    // Start is called before the first frame update
    void Start()
    {
      //  button.onClick.AddListener(OnButtonClick);

      /*  redPage = GameObject.FindGameObjectWithTag("RedPage");
        orangePage = GameObject.FindGameObjectWithTag("OrangePage");
        yellowPage = GameObject.FindGameObjectWithTag("YellowPage");
        greenPage = GameObject.FindGameObjectWithTag("GreenPage");
        bluePage = GameObject.FindGameObjectWithTag("BluePage");
        purplePage = GameObject.FindGameObjectWithTag("PurplePage");
        coverPage = GameObject.FindGameObjectWithTag("CoverPage");*/

        redPage.SetActive(false);
        orangePage.SetActive(false);
        yellowPage.SetActive(false);
        greenPage.SetActive(false);
        bluePage.SetActive(false);
        purplePage.SetActive(false);
        coverPage.SetActive(true);
        purpleLock.enabled = false;
        yellowLock.enabled = false;
        orangeLock.enabled = false;
        orangeLock.enabled = false;
        currentPage = "Cover";
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPage == "Purple")
        {
            PurpleLocked();
        }
        if (currentPage == "Green")
        {
            GreenLocked();
        }
        if (currentPage == "Orange")
        {
            OrangeLocked();
        }
        if (currentPage == "Yellow")
        {
            YellowLocked();
        }
    }

    public void CoverForward()
    {
        coverPage.SetActive(false);
        redPage.SetActive(true);
        currentPage = "Red";
       
    }
    public void RedBack()
        {
            coverPage.SetActive(true);
        redPage.SetActive(false);
        currentPage = "Cover";
    }

    public void RedForward()
    {
        redPage.SetActive(false);
        yellowPage.SetActive(true);
        currentPage = "Yellow";
        YellowLocked();
    }

    public void YellowBack()
    {
        redPage.SetActive(true);
        yellowPage.SetActive(false);
        currentPage = "Red";
    }

    public void YellowForward()
    {
        yellowPage.SetActive(false);
        bluePage.SetActive(true);
        currentPage = "Blue";
    }

    public void BlueBack()
    {
        bluePage.SetActive(false);
        yellowPage.SetActive(true);
        currentPage = "Yellow";
        YellowLocked();
    }

    public void BlueForward()
    {
        bluePage.SetActive(false);
        orangePage.SetActive(true);
        currentPage = "Orange";
        OrangeLocked();
    }

    public void OrangeBack()
        {
        bluePage.SetActive(true);
        orangePage.SetActive(false);
        currentPage = "Blue";
    }

    public void OrangeForward()
    {
        greenPage.SetActive(true);
        orangePage.SetActive(false);
        currentPage = "Green";
        GreenLocked();
    }

    public void GreenBack()
    {
        greenPage.SetActive(false);
        orangePage.SetActive(true);
        currentPage = "Orange";
        OrangeLocked();
    }

    public void GreenForward()
    {
        greenPage.SetActive(false);
        purplePage.SetActive(true);
        currentPage = "Purple";
        PurpleLocked();
    }

    public void PurpleBack()
    {
        greenPage.SetActive(true);
        purplePage.SetActive(false);
        currentPage = "Green";
        GreenLocked();

    }

    public void PurpleLocked()
    {
        purpleLock.enabled = false;
        yellowLock.enabled = false;
        orangeLock.enabled = false;
        orangeLock.enabled = false;
        if (PlayerPrefs.GetInt("Current") <= 2)
        {
            purpleLock.enabled = true;
        }
        else
        {
            purpleLock.enabled = false;
        }
    }

    public void YellowLocked()
    {
        purpleLock.enabled = false;
        yellowLock.enabled = false;
        orangeLock.enabled = false;
        orangeLock.enabled = false;
        if (PlayerPrefs.GetInt("Current") <= 3)
        {
            yellowLock.enabled = true;
        }
        else
        {
            yellowLock.enabled = false;
        }
    }

    public void OrangeLocked()
    {
        purpleLock.enabled = false;
        yellowLock.enabled = false;
        orangeLock.enabled = false;
        orangeLock.enabled = false;
        if (PlayerPrefs.GetInt("Current") <= 4)
        {
            orangeLock.enabled = true;
        }
        else
        {
            orangeLock.enabled = false;
        }
    }
    public void GreenLocked()
    {
        purpleLock.enabled = false;
        yellowLock.enabled = false;
        orangeLock.enabled = false;
        orangeLock.enabled = false;
        if (PlayerPrefs.GetInt("Current") <= 4)
        {
            greenLock.enabled = true;
        }
        else
        {
            greenLock.enabled = false;
        }
    }
}

