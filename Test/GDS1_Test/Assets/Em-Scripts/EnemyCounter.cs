using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    int enemiesCured;
    public Text enemyCounter;
    public int sceneload;
    // Start is called before the first frame update
    void Start()
    {
        enemiesCured = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesCured == 15)
        {
            Debug.Log("You Win!");
            SceneManager.LoadScene("WinScene");
            NextButton();
        }
        
    }

    public void EnemyCured()
    {
        enemiesCured += 1;
        enemyCounter.text = enemiesCured.ToString() + "/15";
    }

    public void NextButton()
    {

        sceneload = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("Current", sceneload);
        SceneManager.LoadScene("InventoryandCrafting");


    }
}
