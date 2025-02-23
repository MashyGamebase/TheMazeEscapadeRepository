using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Score System")]
    public float currentScore;

    private void Start()
    {
        currentScore = 0;
    }

    public void AddScore(float score)
    {
        currentScore = score;
    }
}