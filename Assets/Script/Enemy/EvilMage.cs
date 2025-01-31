using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMage : MonoBehaviour
{
    private GameObject Player;
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
    private bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        AttackRange = transform.GetChild(0).gameObject;
        PlayerPos = Player.transform.position;
        OriginPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Sprite = rb.GetComponent<SpriteRenderer>();
        animator = rb.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > Delay)
        {
            canAttack = true; 
        }
        if(canAttack)
        {
            Timer = 0;
            animator.Play("EvilMage@Run");
            canAttack = false;
        }
    }

    private void Attack()
    {
        Force = 15;
        Vector3 target = PlayerPos - transform.position;
        rb.velocity = new Vector3(target.x, target.y).normalized * Force;
    }

    private void AttackActive()
    {
        AttackRange.SetActive(true);
    }
    private void AttackInactive()
    {
        AttackRange.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Force = 0;
            Debug.Log("Attacking");
            animator.Play("EvilMage@Attack");
            Debug.Log("AttackDone");
        }
    }

    private void hasAttack()
    {
        Timer = 0;
        transform.position = OriginPos;
        AttackRange.SetActive(false);
    }
    private void PlaySound()
    {
        AudioManager.PlayAudio(SoundType.Steps);
    }
}
