using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyCounter : MonoBehaviour
{

    public int enemiesInLevel;
    int enemiesRemaining;
    bool doorUnlocked;
    // Start is called before the first frame update
    void Start()
    {
        enemiesRemaining = enemiesInLevel;
        doorUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyCuredCount()
    {
        enemiesRemaining -= 1;
        if(enemiesRemaining == 0)
        {
            doorUnlocked = true;
            //door unlocked sound
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (doorUnlocked == true)
            {

            }
            else
            {
                //play door locked sound
                //UI popup enemies still remaining
            }
        }
    }
}
