using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Ranged : MonoBehaviour
{
    public GameObject stone;
    public GameObject Target;
    public Transform spawn;
    private Animator animator;
    public float interval = 5;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Target = GameObject.FindWithTag("Player");
        spawn = Target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Attack();
            animator.SetTrigger("Attack");
            timer = 0;
        }
    }

    private void Attack()
    { 
        Instantiate(stone,spawn.position, Quaternion.identity);
    }
}
