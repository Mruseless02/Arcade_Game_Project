using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public string tags;
    public int Damage = 10;
    private Animator animator;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player_Hp>() != null)
        {
            Player_Hp player_Hp = collider.GetComponent<Player_Hp>();
            player_Hp.Hit(Damage);
        }
        if (collider.GetComponent<Enemy_Hp>() != null)
        {
            Enemy_Hp enemy_Hp = collider.GetComponent<Enemy_Hp>();
            enemy_Hp.takingDamage(Damage);
        }
        if (collider.CompareTag(tags))
        {
            force = 0;
            animator.SetTrigger("Hit");
            Debug.Log("Enemyhit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(force, 0);
    }
}
