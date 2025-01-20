using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public BaseHealth playerHealth;
    public Image healthBarBar;
    public TextMeshProUGUI healthText;

    public void Update()
    {
        healthBarBar.fillAmount = playerHealth.GetCurrentPlayerHealth() / playerHealth.startingHealth;
        healthText.text = Mathf.Floor(playerHealth.GetCurrentPlayerHealth()) + "/" + playerHealth.startingHealth;
    }
}
