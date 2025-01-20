using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public int startingHealth = 100;
    [SerializeField] private int currentPlayerHealth;

    public void Start()
    {
        ResetPlayerHealth();
        currentPlayerHealth = startingHealth;
    }

    public void ResetPlayerHealth()
    {
        currentPlayerHealth = startingHealth;
    }

    public void DamagePlayer(int amt)
    {
        currentPlayerHealth -= amt;

        if (currentPlayerHealth <= 0) 
        {
            GameOver();
        }
    }

    public float GetCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
