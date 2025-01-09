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
    private BossDrop Drops;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 target;
    private float timer;
    private float intervals;
    private bool canAtttack;
    [SerializeField]
    private GameObject[] Rise;
    int maxRise = 2;
    int count = 0;
    bool canRise;
    void Start()
    {
        
        Player = GameObject.FindWithTag("Player");
        Drops = GetComponent<BossDrop>();
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
        if(hp.Hp == hp.Hp/2 && count <= maxRise)
        {
            SummonEnemy();
        }
    }

    private void SummonEnemy()
    {
        if (count < maxRise && canRise)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            animator.Play("Necromancer@Rise");
            count++;
        }
    }

    void attack(int attackType)
    {
       if(attackType <= 4)
        {
            animator.Play("Necromancer@Attack");
            timer = 0;
            canAtttack = false;
        }
       if(attackType >= 5)
        {
            animator.Play("Necromancer@Attack 2");
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
