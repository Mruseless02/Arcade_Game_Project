using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Melee : MonoBehaviour
{
    private Vector3 originalPos;
    public Transform TargetPos;
    public GameObject TargetPlayer;
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator animator;
    private Enemy_Hp hp;
    private GameObject attack_range = default;
    private SpriteRenderer sprite;
    private bool isAttacking = false;
    public float intervals;
    private float timer;
    private float force;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        hp = GetComponent<Enemy_Hp>();
        attack_range = transform.GetChild(0).gameObject;
        TargetPlayer = GameObject.FindWithTag("Player");
        TargetPos = TargetPlayer.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalPos = transform.position;
        Flip();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= intervals)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(timer >= intervals)
        {
            force = 10;
            animator.SetTrigger("Walk");
            Vector3 target = TargetPos.position - originalPos;
            rb.velocity = new Vector3(target.x, target.y).normalized * force;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {                                                                                              
            if(!isAttacking)
            {
                timer = 0;
                force = 0;
                animator.SetTrigger("Attack");
                isAttacking = true;
            }           
        }
    }
    private void Flip()
    {
        if (transform.position.x > TargetPos.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
    private void AttackActive()
    {
        attack_range.SetActive(true);
    }
    private void hasAttack()
    {
        isAttacking = false;
        attack_range.SetActive(false);
        transform.position = originalPos;
    }

    private void PlaySound()
    {
        AudioManager.PlayAudio(SoundType.Steps);
    }
}
