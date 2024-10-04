using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Point : MonoBehaviour
{
    public GameObject[] Enemy;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        var enemy = Random.Range(0, Enemy.Length);
        Instantiate(Enemy[enemy], SpawnPoint.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
