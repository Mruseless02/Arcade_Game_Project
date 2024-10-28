using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerActive : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
