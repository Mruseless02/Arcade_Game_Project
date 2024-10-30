using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    //Eenemy melee
    //enemy tag
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player_Control>() != null)
        {
            Player_Control player = collision.GetComponent<Player_Control>();
            player.combat = true;
        }
    }
}
