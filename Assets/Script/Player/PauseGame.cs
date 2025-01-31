using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject ui;
    public GameObject Pausmenu;
    public Animator animator;


    public void pause()
    {
        Time.timeScale = 0f;
    }

    public void onClick()
    {
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        animator.SetBool("isPaused",false);
        Time.timeScale = 1f;
        ui.SetActive(true);
    }
}
