using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Keys : MonoBehaviour
{
    bool hasRun = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Control>() != null && !hasRun)
        {
            hasRun = true;
            Player_Control key = collision.GetComponent<Player_Control>();
            key.KeyCheck(1);
            Destroy(gameObject);
        }
    }
}
