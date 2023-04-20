using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeButton : MonoBehaviour
{
    //[SerializeField] private string escapeBut = "InventoryAndCrafting";

    public void NewGameButton()
    {
        SceneManager.LoadScene("Jes-SampleScene");
    }
}
