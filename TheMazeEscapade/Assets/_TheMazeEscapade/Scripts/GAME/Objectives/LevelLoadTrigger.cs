using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoadTrigger : MonoBehaviour
{
    public string LevelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FadeCanvasController.Instance.FadeLoadLevel(LevelToLoad);
        }
    }
}