using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelStartSequencer : MonoBehaviour
{
    public Animator animator;
    public Image fadeImage;

    public UnityEvent OnSequenceEnd;

    void Start()
    {
        fadeImage.enabled = true;
        animator.SetTrigger("PopAndFade");
    }

    public void SequenceEnd()
    {
        fadeImage.enabled = false;
        //animator.ResetTrigger("PopAndFade");
        OnSequenceEnd?.Invoke();
    }
}