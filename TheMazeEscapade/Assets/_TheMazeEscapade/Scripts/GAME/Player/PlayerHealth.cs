using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image healthIcon;

    //private LevelObjectives LevelObj => LevelObjectives.Instance;

    private void Start()
    {
        currentHealth = maxHealth;
        healthIcon.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    public void TakeDamage(int damage, Vector2 source, float force)
    {
        currentHealth -= damage;
        GetComponent<Player2DMovement>().TakeDamage(source, force);

        if (currentHealth <= 0)
        {
            // Die
            // Gameover Screen
            //LevelObjectives.Instance.Game_OnLose();
            GetComponentInChildren<PlayerCanvasController>().RestartButton();
        }

        healthIcon.fillAmount = (float)currentHealth / (float)maxHealth;
    }
}