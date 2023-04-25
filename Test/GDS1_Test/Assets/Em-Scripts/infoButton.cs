using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class infoButton : MonoBehaviour
{
    [SerializeField] private string colourInformation = "g-wheelInfo";

    public void NewGameButton()
    {
        SceneManager.LoadScene(colourInformation);
    }
}
