using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCanvasController : MonoBehaviour
{
    public void RestartButton()
    {
        FadeCanvasController.Instance.FadeLoadLevel(SceneManager.GetActiveScene().name);
    }

    public void HomeButton()
    {
        FadeCanvasController.Instance.FadeLoadLevel("Main Menu");
    }
}