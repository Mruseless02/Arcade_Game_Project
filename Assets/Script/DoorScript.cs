using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private Collider2D coll;
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Enemy") == null)
        {
            coll.enabled = false;
            animator.SetTrigger("Open");
        }
        else if(GameObject.FindWithTag("Enemy") != null)
        {
            coll.enabled = true;
            animator.SetTrigger("Close");
        }
    }
}
