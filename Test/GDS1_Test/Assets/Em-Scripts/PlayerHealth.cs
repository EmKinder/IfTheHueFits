using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    public void DealDamage(float damage)
    {
        playerHealth -= damage;
        healthBar.fillAmount = playerHealth / 100;
        
    }

    public void CheckHealth()
    {
        if(playerHealth <= 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }

    public void DealHealth(float health)
    {
        playerHealth += health;
        healthBar.fillAmount = playerHealth / 100;

    }
}
