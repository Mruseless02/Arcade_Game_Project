using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flame : MonoBehaviour
{
    private Transform aim;
    private GameObject sight;
    private int Damage = 5;

    private void Start()
    {
        sight = GameObject.Find("Aim");
        aim = sight.transform;
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player_Hp>() != null)
        {
            Player_Hp hp = collision.GetComponent<Player_Hp>();
            hp.Hit(Damage);
        }
    }

    
    private void Rotate()
    {
        Vector3 rotation = aim.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void Destroy()
    {
        Destroy(gameObject); 
    }
}
