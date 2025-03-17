using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerActive : MonoBehaviour
{
    private void Update()
    {
        float check;
        check = Time.fixedTime;

        if (check > 0.45)
        {
            CheckEnemy();
            check = 0;
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
            Debug.Log("Enemy Not Found");
            GetComponent<CameraSeting>().StandartCamera();
            GetComponent<ChangeMusic>().returnAudio();
        }
        Debug.Log("Enemy Found");
    }
}
