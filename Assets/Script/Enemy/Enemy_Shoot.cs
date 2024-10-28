using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public float force;
    public int damage;
    private Vector3 Origin;
    private Rigidbody2D rb;
    public GameObject Player;
    public Transform PlayerPos;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Origin = transform.position;
        Player = GameObject.FindWithTag("Player");
        PlayerPos = Player.transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            force = 0;
            animator.SetTrigger("Hit");
            if(collision.GetComponent<Player_Hp>() != null)
            {
                Player_Hp player_Hp = collision.GetComponent<Player_Hp>();
                player_Hp.Hit(damage);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        {
            Vector3 Direction = PlayerPos.position - Origin;
            rb.velocity = new Vector3(Direction.x, Direction.y).normalized * force;
        }

    }
}
