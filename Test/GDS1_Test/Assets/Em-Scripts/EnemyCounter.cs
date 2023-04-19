using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    int enemiesCured;
    public Text enemyCounter;
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
            SceneManager.LoadScene(3);
        }
    }

    public void EnemyCured()
    {
        enemiesCured += 1;
        enemyCounter.text = enemiesCured.ToString() + "/15";
    }
}
