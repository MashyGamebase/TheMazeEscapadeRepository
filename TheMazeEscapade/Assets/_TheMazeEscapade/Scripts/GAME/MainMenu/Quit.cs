using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("It WORKS");

    }
}
