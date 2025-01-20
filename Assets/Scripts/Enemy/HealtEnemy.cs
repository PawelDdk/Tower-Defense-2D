using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtEnemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int moneyWorth = 50;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroyed.Invoke();
            LevelManager.main.IncreaseMoney(moneyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

}
