using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    [SerializeField] private string returnBack = "AmmoCountTesting";

    public void NewGameButton()
    {
        SceneManager.LoadScene(returnBack);
    }

}
