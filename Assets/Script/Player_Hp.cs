using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{
    public int HP = 100;
    private int MaxHp = 10000;
    private bool canTakeDamage;
    private float damageInterval = 2f;
    private float timer = 0f;
    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        timer = Time.deltaTime;
        if(timer < damageInterval)
        {
            canTakeDamage = true;
        }
        Dead();
    }

    private void Dead()
    {
        if(HP <= 0)
        {
            animator.SetTrigger("Dead");
        }
    }
    public void Healing(int ammount)
    {
        if(HP < MaxHp)
        {
            this.HP += ammount;
        }
    }

    public void Hit(int ammount)
    {
        if(canTakeDamage)
        {
            animator.SetTrigger("Hit");
            this.HP -= ammount;
            canTakeDamage = false;
            timer = 0f;
        }
        
    }
}
