using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private Collider2D coll;
    private bool doorIsOpen;
    private float timer;
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.fixedTime;
        if (GameObject.FindWithTag("Enemy") != null)
        {
            coll.enabled = true;
            doorIsOpen = false;
            animator.SetTrigger("Close");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Intereact"))
        {
            float interact_Delay = 0.75f;

            if(timer > interact_Delay)
            {
                if (!doorIsOpen)
                {
                    coll.isTrigger = true;
                    animator.SetBool("Open", true);
                    doorIsOpen = true;
                    timer = 0;
                }
                else if (doorIsOpen)
                {
                    coll.isTrigger = false;
                    animator.SetBool("Open", false);
                    doorIsOpen = false;
                    timer = 0;
                }
            }
        }
    }

    private void PlayAudioOpen()
    {
        AudioManager.PlayAudio(SoundType.DoorOpen);
    }

    private void PlayAudioClose()
    {
        AudioManager.PlayAudio(SoundType.DoorClose);
    }
}
