using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class UdeadExecutioner : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject AttackRad;
    [SerializeField]
    private GameObject Summons;
    [SerializeField]
    private GameObject[] SummonPos;
    private Animator animator;
    public GameObject Player;
    private Vector3 Origin;
    public UndeadSummon[] Spirit;
    private float Force;
    private float  timer = 0;
    private float SpawnTime = 0;
    [SerializeField]
    private float SpawnInterval = 2;
    [SerializeField]
    private float interval = 10;
    public int Spawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        Origin = gameObject.transform.position;
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTime += Time.deltaTime;
        timer += Time.deltaTime;
        if(timer > interval)
        {
            Attack();
        }
        if(SpawnTime > SpawnInterval)
        {
            if (Spawn < SummonPos.Length)
            {
                Summon();
            }
            if(Spawn == SummonPos.Length)
            {
                if (GameObject.FindWithTag("Summons") == null)
                {
                    Spawn = 0;
                }
                var Ghost = GameObject.FindWithTag("Summons").GetComponent<UndeadSummon>();
                for (int i = 0; i < SummonPos.Length; i++)
                {
                    Spirit[i] = Ghost;
                    Ghost.AttackPlayer();
                    
                }
            }
        }
    }


    private void Attack()
    {

        Force = 10f;
        Vector3 target = Player.transform.position - transform.position;
        animator.Play("Undead@chasePlayer");
        rb.velocity = new Vector3(target.x, target.y).normalized * Force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Force = 0;
            timer = 0;
            AttackRad.SetActive(true);
            animator.Play("Undead@Attack");
        }
    }
    private void Summon()
    {
        if(Spawn != SummonPos.Length)
        {
            var SpawnPos = SummonPos[Spawn];
            Instantiate(Summons, SpawnPos.transform.position , Quaternion.identity);
            Spawn++;
            SpawnTime = 0;
        }
    }

    private void hasAttack()
    {
        AttackRad.SetActive(false);
        transform.position = Origin;
    }
}
