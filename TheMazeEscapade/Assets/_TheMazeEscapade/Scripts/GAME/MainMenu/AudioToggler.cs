using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggler : MonoBehaviour
{
    public bool isMusicOn = true;
    public AudioSource audioSource;

    public Image musicButton;
    public Sprite musicOnSprite, musicOffSprite;

    private void Start()
    {
        int value = PlayerPrefs.HasKey("Music") ? PlayerPrefs.GetInt("Music") : 1;

        audioSource.volume = value == 1 ? 0.05f : 0;
        musicButton.sprite = value == 1 ? musicOnSprite : musicOffSprite;
        isMusicOn = value == 1;
    }

    public void ToggleMusic()
    {
        if (isMusicOn)
        {
            isMusicOn = false;
            musicButton.sprite = musicOffSprite;
            audioSource.volume = 0;
            PlayerPrefs.SetInt("Music", 0);
            PlayerPrefs.Save();
        }
        else if(!isMusicOn)
        {
            isMusicOn = true;
            musicButton.sprite = musicOnSprite;
            audioSource.volume = 0.05f;
            PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.Save();
        }
    }
}