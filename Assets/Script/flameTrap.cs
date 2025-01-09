using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class flameTrap : MonoBehaviour
{
    public GameObject trap;
    public Transform Spawn;
    private Animator animator;
    private float Timer = 0f;
    private float interval = 10f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Spawn = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= interval)
        {
            Instantiate(trap, Spawn.position, Quaternion.identity);
            animator.SetTrigger("Active");
            if (GameObject.Find("FireBreath") == null)
            {
                animator.SetTrigger("Charge");
                Timer = 0f;
            }
        }
    }
}
