using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<ChangeMusic>().changeAudio();
        }
    }
}
