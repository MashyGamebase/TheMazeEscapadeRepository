using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    internal int currentHealth;
    public int maxHealth;

    public Image healthIcon;

    private LevelObjectives LevelObj => LevelObjectives.Instance;

    private void Start()
    {
        currentHealth = maxHealth;
        healthIcon.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Die
            // Gameover Screen
            LevelObjectives.Instance.Game_OnLose();
        }

        healthIcon.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}