using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Control>()!= null)
        {
            gameObject.tag = "Enemy";
            animator.SetTrigger("Rise");
            Rise();
        }
    }
    private void Rise()
    {
        GetComponent<ChangeMusic>().changeAudio();
        GetComponent<Enemy_Melee>().enabled = true;
        Destroy(this);
    }

    private void dead()
    {
        GetComponent<ChangeMusic>().returnAudio();
    }
}
