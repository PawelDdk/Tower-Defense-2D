using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BaseHealth playerHealth;
    public int damageAmount = 10;

    private void Start()
    {
        playerHealth = FindObjectOfType<BaseHealth>(); 
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Base")) 
        {
            playerHealth.DamagePlayer(damageAmount);
        }
    }

}
