using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Ranged : MonoBehaviour
{
    public GameObject stone;
    public Transform spawn;
    public float interval = 5;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Attack();
            timer = 0;
        }
    }

    private void Attack()
    {
        Instantiate(stone,transform.position, Quaternion.identity);
    }
}
