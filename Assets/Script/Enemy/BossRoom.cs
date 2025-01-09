using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    public bool inCombat = false;
    public CinemachineVirtualCamera vcam;
    public Transform bossZone;
    public GameObject boss;
    private void Start()
    {
        bossZone = GetComponent<Transform>();
    }

    private void Update()
    {
        if (inCombat)
        {
            boss.SetActive(true);
            boss.tag = "Enemy";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player_Control>() != null)
        {
            Player_Control player = collision.GetComponent<Player_Control>();
            player.combat = true;
            vcam.Follow = bossZone.transform;
            inCombat = true;
        }
    }
}
