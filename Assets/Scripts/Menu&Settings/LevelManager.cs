using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform[] path;
    public Transform start;

    public int money;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        money = 100;
    }

    public void IncreaseMoney(int amount)
    {
        money += amount;
    }

    public bool SpendMoney(int amount)
    {
        if (amount <= money) 
        { 
            //kup przedmiot
            money -= amount;
            return true;
        }
        else
        {
            Debug.Log("Nie masz wystarczaj¹c¹ iloœæ pieniêdzy by kupiæ ten przedmiot");
            return false;
        }
    }
}
