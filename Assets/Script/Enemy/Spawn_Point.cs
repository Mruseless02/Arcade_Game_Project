using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawn_Point : MonoBehaviour
{
    public int maxSpawn;
    public int count = 0;
    public GameObject[] Enemy;
    public Vector3 SpawnPoint;
    bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = gameObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(!hasSpawned && count != maxSpawn)
        {
            Spawn();
            count++;
        }
        if(GameObject.FindWithTag("Enemy") == null)
        {
            hasSpawned = false;
        }
    }
    
    private void Spawn()
    {
        var enemy = Random.Range(0, Enemy.Length);
        Instantiate(Enemy[enemy],SpawnPoint, Quaternion.identity);
        hasSpawned = true;
    }
}
