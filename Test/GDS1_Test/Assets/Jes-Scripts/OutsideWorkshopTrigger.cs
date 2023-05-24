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
    public Image huemansRemainingUI;
    bool doorLockedTimerBool;
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        winscene.enabled = false;
        enemiesRemaining = enemiesInLevel;
        doorUnlocked = false;
        huemansRemainingUI.enabled = false;
        doorLockedTimerBool = false;
      //  doorLockedTimer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorLockedTimerBool)
        {
            huemansRemainingUI.enabled = true;
            timer += Time.deltaTime;
            if(timer >= 1.5f)
            {
                huemansRemainingUI.enabled = false;
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
            if (doorUnlocked)
            {
                winscene.enabled = true;
            }
            else
            {
                //play door locked sound
                doorLockedTimerBool = true;
            }
        }
    }
}
