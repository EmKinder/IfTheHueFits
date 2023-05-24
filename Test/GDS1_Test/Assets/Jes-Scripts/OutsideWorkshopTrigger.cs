using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutsideWorkshopTrigger : MonoBehaviour
{
    public int enemiesInLevel;
    int enemiesRemaining;
    public Canvas winscene;
    bool doorUnlocked;
    public Canvas huemansRemainingUI;
    bool doorLockedTimerBool;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        winscene.enabled = false;
        enemiesRemaining = enemiesInLevel;
        doorUnlocked = false;
        huemansRemainingUI.gameObject.SetActive(false);
        doorLockedTimerBool = false;
      //  doorLockedTimer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorLockedTimerBool)
        {
            Debug.Log("Should be popping up");
            huemansRemainingUI.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if(timer >= 1.5f)
            {
                huemansRemainingUI.gameObject.SetActive(false);
                timer = 0; 
                doorLockedTimerBool = false;
            }
        }
    }


    public void EnemyCuredCount()
    {
        enemiesRemaining -= 1;
        if (enemiesRemaining == 0)
        {
            doorUnlocked = true;
            //door unlocked sound
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("House triggered");
            if (doorUnlocked)
            {
                Debug.Log("Huemans cured");
                winscene.enabled = true;
            }
            else
            {
                Debug.Log("Huemans not cured");
                //play door locked sound
                doorLockedTimerBool = true;
            }
        }
    }
}
