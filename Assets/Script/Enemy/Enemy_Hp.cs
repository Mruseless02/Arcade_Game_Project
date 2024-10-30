using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hp : MonoBehaviour
{
    public int minHP = 15;
    public int maxHP = 25;
    public int Hp;
    private Rigidbody2D rb;
    private Collider2D col;
    private Enemy_Melee melee;
    private Animator animator;
    
        
    // Start is called before the first frame update
    void Start()
    {
        Hp = Random.Range(minHP,maxHP);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        DestroyGameObject();
    }

    private void DestroyGameObject()
    {
        if(Hp <= 0)
        {
            Debug.Log("Died");
            animator.SetTrigger("Died");
            gameObject.tag = "Untagged";
        }
    }

    public void takingDamage(int ammount)
    {
        animator.SetTrigger("Hit");
        this.Hp -= ammount;  
    }
}
