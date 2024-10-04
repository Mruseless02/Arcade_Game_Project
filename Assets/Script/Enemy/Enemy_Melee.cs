using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Melee : MonoBehaviour
{
    private Vector3 currentPos;
    public Transform TargetPos;
    public GameObject TargetPlayer;
    private Rigidbody2D rb;
    private Animator animator;
    public float intervals;
    private float timer;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer = GameObject.FindWithTag("Player");
        TargetPos = TargetPlayer.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPos = transform.position;

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
            Vector3 target = TargetPos.position - currentPos;
            rb.velocity = new Vector3(target.x, target.y).normalized * force;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            force = 0;
        }
    }
}
