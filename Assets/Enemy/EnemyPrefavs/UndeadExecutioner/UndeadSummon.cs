using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadSummon : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject Player;
    private int damage = 1;
    private float force;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
    }


    public void AttackPlayer()
    {
        force = 10;
        Vector3 Target = Player.transform.position - transform.position;
        rb.velocity = new Vector2(Target.x, Target.y).normalized * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Hp>() != null)
        {
            Player_Hp hp = collision.GetComponent<Player_Hp>();
            hp.Hit(damage);
            animator.SetTrigger("Hit");
            Destroy(gameObject);
        }
    }
}
