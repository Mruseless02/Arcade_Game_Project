using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.U2D;

public class DeathBringger : MonoBehaviour
{
    private GameObject Player;
    [SerializeField]
    private GameObject Spell;
    private GameObject AttackRange;
    private Vector3 PlayerPos;
    private Vector3 OriginPos;
    private Rigidbody2D rb;
    private SpriteRenderer Sprite;
    private Animator animator;
    [SerializeField]
    private float Force;
    [SerializeField]
    private float Timer;
    [SerializeField]
    private float Delay;
    private int rand;
    private bool canAttack = false;


    // Start is called before the first frame update
    void Start()
    {
        randomVal();
        Sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        PlayerPos = Player.transform.position;
        OriginPos = gameObject.transform.position;
        AttackRange = transform.GetChild(0).gameObject;
        flip();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > Delay)
        {
            canAttack = true;
        }
        if (canAttack)
        {
            Attack(rand);
        }

    }

    private void randomVal()
    {
        rand = Random.Range(0, 9);
    }
    private void Attack(int rand )
    {
        if(rand <= 4)
        {
            Timer = 0;
            animator.Play("DearhBringger@Cast");
            canAttack = false;
            randomVal();
        }
        if(rand >= 5)
        {
            Timer = 0;
            animator.Play("DearhBringger@Walk");
            canAttack = false;
            randomVal();
        }
    }

    private void RangeAttack()
    {
        Instantiate(Spell,PlayerPos,Quaternion.identity);
    }

    private void MeleeAttack() 
    {
        Force = 15;
        Vector3 target = PlayerPos - transform.position;
        rb.velocity = new Vector3(target.x, target.y).normalized * Force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Force = 0;
            AttackRange.SetActive(true);
            animator.Play("DearhBringger@Attack");
            canAttack = false;
        }
    }

    private void hasAttack()
    {
        AttackRange.SetActive(false);
        transform.position = OriginPos;
    }

    private void flip()
    {
       if(transform.position.x > PlayerPos.x)
       {
            Sprite.flipX = true;
       }
        else
        {
            Sprite.flipY = false;
        }
    }
    private void PlaySound()
    {
       AudioManager.PlayAudio(SoundType.Steps);
    }
}
