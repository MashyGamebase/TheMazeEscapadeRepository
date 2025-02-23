using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    LevelObjectives LevelObj => LevelObjectives.Instance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (LevelObj.hasKey)
            {
                LevelObj.Game_OnWin();
            }
            else
            {
                collision.gameObject.GetComponent<PlayerCanvas>().SetText("I need to find the key.");
            }
        }
    }
}