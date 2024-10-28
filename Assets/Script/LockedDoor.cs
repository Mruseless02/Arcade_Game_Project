using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private Animator animator;
    public Collider2D coll;
    public Player_Control player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        player = GetComponent<Player_Control>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Intereact"))
        {
            GetComponent<Player_Control>();
            Player_Control player_Control;
            player_Control = GetComponent<Player_Control>();

            if (player_Control.Have_Key)
            {
                coll.enabled = false;
                animator.SetTrigger("Open");
            }
        }
    }
}
