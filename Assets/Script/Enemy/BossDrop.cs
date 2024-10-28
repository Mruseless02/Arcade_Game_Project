using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrop : MonoBehaviour
{
    private Enemy_Hp hp;
    public GameObject keys;
    public GameObject[] drops;
    void Start()
    {
        hp = GetComponent<Enemy_Hp>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp.Hp == 0)
        {
            var rand = Random.Range(0,drops.Length);
            Vector3 Position = transform.position;
            Instantiate(keys, Position, Quaternion.identity);
            Instantiate(drops[rand], Position, Quaternion.identity);
        }
    }
}
