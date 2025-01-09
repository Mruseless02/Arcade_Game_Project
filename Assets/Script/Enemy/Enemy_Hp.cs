using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hp : MonoBehaviour
{
    public int minHP = 15;
    public int maxHP = 25;
    public int Hp;
    [SerializeField]
    private ParticleSystem particle;
    private ParticleSystem particleInstance;
    private Rigidbody2D rb;
    private Collider2D col;
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
            animator.Play("Enemy@Animation@Died");
        }
    }

    public void takingDamage(int ammount)
    {
        DamageParticle();
        animator.SetTrigger("Hit");
        this.Hp -= ammount;  
    }

    private void DamageParticle()
    {
        particleInstance = Instantiate(particle, transform.position, Quaternion.identity);
    }
}