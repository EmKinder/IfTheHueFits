using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class infoButton : MonoBehaviour
{
    //[SerializeField] private string colourInformation = "g-wheelInfo";

    public void NewGameButton()
    {
        SceneManager.LoadScene("g-wheelInfo");
    }
}
