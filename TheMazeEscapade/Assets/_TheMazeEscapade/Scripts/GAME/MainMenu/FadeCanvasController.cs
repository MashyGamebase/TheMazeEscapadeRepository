using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeCanvasController : MonoBehaviour
{
    public static FadeCanvasController Instance { get; private set; }

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject loaderUI;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FadeLoadLevel(string levelToLoad)
    {
        StartCoroutine(loadLevelFadeCO(levelToLoad));
    }

    IEnumerator loadLevelFadeCO(string levelToLoad)
    {
        animator.SetTrigger("PopIn");

        yield return new WaitForSeconds(0.5f);

        loaderUI.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadSceneAsync(levelToLoad);

        yield return new WaitForSeconds(0.8f);

        loaderUI.SetActive(false);

        animator.SetTrigger("PopOut");
    }
}