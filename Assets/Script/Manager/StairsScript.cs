using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsScript : MonoBehaviour
{
    private GameObject Stairs;
    public KeyCode stairUp;
    public KeyCode stairDown;

    private void Start()
    {
        Stairs = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKey(stairDown))
        {
            Stairs.SetActive(false);
        }
        else if (collision.CompareTag("Player") && Input.GetKey(stairUp))
        {
            Stairs.SetActive(true);
        }
    }
}
