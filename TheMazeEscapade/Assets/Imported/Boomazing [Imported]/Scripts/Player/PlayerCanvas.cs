using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    [Header("Canvas Components")]
    public Canvas playerCanvas;
    public TMP_Text playerText;
    Coroutine sayCoroutine;

    public void SetText(string text, float duration = 3)
    {
        if(sayCoroutine == null)
        {
            sayCoroutine = StartCoroutine(SayText(text, duration));
        }
        else
        {
            StopCoroutine(sayCoroutine);
            sayCoroutine = null;
            sayCoroutine = StartCoroutine(SayText(text, duration));
        }
    }

    IEnumerator SayText(string text, float duration)
    {
        playerText.text = text;

        yield return new WaitForSeconds(duration);

        playerText.text = "";
        sayCoroutine = null;
    }

    public void TogglePlayerCanvas(bool toggle)
    {
        playerCanvas.enabled = toggle;
    }
}