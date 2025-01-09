using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class Enemy_Ranged : MonoBehaviour
{
    public GameObject stone;
    public GameObject Target;
    private SpriteRenderer sprite;
    public Transform TargetPos;
    private Animator animator;
    private AudioSource Audio;
    private bool DefaultState;
    public float interval = 5;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Target = GameObject.FindWithTag("Player");
        TargetPos = Target.transform;
        Audio = GetComponent<AudioSource>();
        Flip();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            animator.SetTrigger("Attack");
            timer = 0;
        }
    }
    private void Flip()
    {
        if(DefaultState == true)
        {
            if (transform.position.x < TargetPos.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else if(DefaultState == false)
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
    }
    private void Attack()
    {
        Instantiate(stone,gameObject.transform.position, Quaternion.identity);
    }
}
