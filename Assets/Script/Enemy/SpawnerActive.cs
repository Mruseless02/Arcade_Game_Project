using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerActive : MonoBehaviour
{
    private void Update()
    {
        float timer;
        timer = Time.unscaledDeltaTime;
        float CheckInterval = 0.25f;

        if (timer > CheckInterval)
        {
            CheckEnemy();
            timer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<ChangeMusic>().changeAudio();
            Spawn();
        }
    }

    private void Spawn()
    {
        GetComponent<CameraSeting>().CombatCamera();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void CheckEnemy()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            GetComponent<CameraSeting>().StandartCamera();
            GetComponent<ChangeMusic>().returnAudio();
        }
    }
}
