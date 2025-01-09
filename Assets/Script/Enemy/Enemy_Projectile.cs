using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public int Damage = 10;
    private GameObject Player;
    private Vector3 projectileSpawn;
    private Animator animator;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = transform.rotation;
        projectileSpawn = transform.position;
        Player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player_Hp>() != null)
        {
            Player_Hp player_hp = collider.GetComponent<Player_Hp>();
            player_hp.Hit(Damage);
        }
        if (collider.CompareTag("Player"))
        {
            force = 0;
            animator.SetTrigger("Hit");
            Debug.Log("Enemyhit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 Target = Player.transform.position - projectileSpawn;
        rb.velocity = new Vector2 (Target.x, Target.y).normalized * force;
        Vector3 rotation = Player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
