using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrop : MonoBehaviour
{
    public GameObject keys;
    public GameObject[] drops;

    public void DropItem()
    {
        var rand = Random.Range(0, drops.Length);
        Instantiate(keys, transform.position, Quaternion.identity);
        Instantiate(drops[rand], transform.position, Quaternion.identity);
        
    }
}
