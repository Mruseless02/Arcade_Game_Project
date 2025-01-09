using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorne : MonoBehaviour
{
    private Vector3 originalPos;
    public Transform TargetPos;
    public GameObject TargetPlayer;
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator animator;
    private Enemy_Hp hp;
    private GameObject attack_range = default;
    private bool isAttacking = false;
    public float intervals;
    private float timer;
    private float force;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        hp = GetComponent<Enemy_Hp>();
        attack_range = transform.GetChild(0).gameObject;
        TargetPlayer = GameObject.FindWithTag("Player");
        TargetPos = TargetPlayer.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= intervals)
        {
            Attack();
        }
        if (hp.Hp <= 0)
        {
            Destroy(coll);
            Destroy(rb);
            Destroy(this);
        }
    }

    private void Attack()
    {
        if (timer >= intervals)
        {
            force = 10;
            Vector3 target = TargetPos.position - originalPos;
            rb.velocity = new Vector3(target.x, target.y).normalized * force;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isAttacking)
            {
                timer = 0;
                force = 0;
                attack_range.SetActive(true);
                animator.SetTrigger("Attack");
                isAttacking = true;
            }
        }
    }
    private void hasAttack()
    {
        isAttacking = false;
        attack_range.SetActive(false);
        transform.position = originalPos;
    }

}
