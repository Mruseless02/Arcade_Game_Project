using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private Collider2D coll;
    private bool doorIsOpen;
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Enemy") != null)
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
            if (!doorIsOpen)
            {
                coll.isTrigger = true;
                animator.SetTrigger("Open");
                doorIsOpen = true;
            }
            else if (doorIsOpen)
            {
                coll.isTrigger = false;
                animator.SetTrigger("Close");
                doorIsOpen = false;
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
