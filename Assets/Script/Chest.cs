using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public GameObject Keys;
    private bool HaveKey;


    private void Start()
    {
        animator = GetComponent<Animator>();
        HaveKey = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Intereact"))
        {
            Debug.Log("Open");
            animator.SetTrigger("Open");
            if (HaveKey == true)
            {
                Instantiate(Keys, gameObject.transform.position, Quaternion.identity);
                HaveKey = false;
            }
        }
    }
}
