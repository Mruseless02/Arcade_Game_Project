using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject PauseUi;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            animator.SetBool("isPaused",true);
            mainUI.SetActive(false);
        }
    }
}
