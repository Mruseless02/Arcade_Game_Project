using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class sceneManager : MonoBehaviour
{
    public GameObject canvas;
    private Scene currscene;
    public static string sceneName;
    public Animator animator;
    private void Start()
    {
        currscene = SceneManager.GetActiveScene();
        sceneName = currscene.name;
    }

    // Start is called before the first frame update
    public void changeScene(string sceneName)
    {
        StartCoroutine(LoadNextScene(sceneName));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);

        Time.timeScale = 1.0f;
    }


    public void ResetScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
    }

    public void quitApp()
    {
        Application.Quit();
    }
    public void Reset()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Cancel()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}

