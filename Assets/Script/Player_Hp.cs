using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hp : MonoBehaviour
{
    public int HP = 100;
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
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hit(int ammount)
    {
        this.HP -= ammount;
    }
}
