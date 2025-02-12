using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class flameTrap : MonoBehaviour
{
    public GameObject trap;
    public Transform Spawn;
    private Animator animator;
    private float Timer = 0f;
    private bool DoneCharging = true;
    public float interval = 10f;
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
        if (Timer >= interval && DoneCharging)
        {
            Instantiate(trap, Spawn.position, Quaternion.identity);
            animator.SetTrigger("Active");
            if (GameObject.Find("FireBreath") == null)
            {
                animator.SetTrigger("Charge");
                DoneCharging=false;
                Timer = 0f;
            }
        }
    }

    private void chargeDone()
    {
        DoneCharging = true;
    }
}
