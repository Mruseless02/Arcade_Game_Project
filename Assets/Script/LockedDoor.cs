using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private Animator animator;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Control>() != null)
        {
            Player_Control player = collision.GetComponent<Player_Control>();
            if (player.Have_Key)
            {
                coll.enabled = false;
                animator.SetTrigger("Open");
                player.Have_Key = false;
            }
        }
    }
}
