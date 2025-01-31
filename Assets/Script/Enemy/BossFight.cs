using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player_Control>() != null)
        {
            boss.tag = "Enemy";
            Player_Control player = collision.GetComponent<Player_Control>();
            player.combat = true;
            StartBattle();
        }
    }
    public void StartBattle()
    {
        GetComponent<CameraSeting>().CombatCamera();
        if(boss == null)
        {
            GetComponent<CameraSeting>().StandartCamera();
        }
    }
}
