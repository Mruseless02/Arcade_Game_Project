using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public GameObject Ground_Attack;
    public GameObject Projectile_Attack;
    public GameObject Player;
    public Transform projectileSpawn;
    private Enemy_Hp hp;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 target;
    private float timer;
    private float intervals;
    private bool canAtttack;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        timer = 0;
        intervals = 5;
        projectileSpawn = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hp = GetComponent<Enemy_Hp>();
    }

    // Update is called once per frame
    void Update()
    {
        var rand = Random.Range(0, 9);
        target = Player.transform.position;
        timer += Time.deltaTime;
        if(timer > intervals)
        {
            canAtttack = true;
        }
        if(canAtttack )
        {
            attack(rand); 
        }
        if(hp.Hp == hp.Hp/2 && GameObject.FindWithTag("Enemy") == null)
        {
            animator.SetTrigger("Rise");
        }
        
    }

    private void SummonEnemy()
    {
        int count = 0;
        int maxRise = 2;
        transform.GetChild(0).gameObject.SetActive(true);
        animator.SetBool("RisenEnemy", true);
        if(GameObject.FindWithTag("Enemy")  == null && count <= maxRise)
        {
            animator.SetBool("RisenEnemy", false);
        }
    }

    void attack(int attackType)
    {
       if(attackType <= 4)
        {
            animator.SetTrigger("Attack1");
            timer = 0;
            canAtttack = false;
        }
       if(attackType >= 5)
        {
            animator.SetTrigger("Attack2");
            timer = 0;
            canAtttack = false;
        }
    }
    void Attack_Ground()
    {
        Instantiate(Ground_Attack, target, Quaternion.identity);
    }
    void Attack_Projectile()
    {
        Instantiate(Projectile_Attack, projectileSpawn.position, Quaternion.identity);
    }
}
