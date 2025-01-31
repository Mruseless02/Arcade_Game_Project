using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    public int PointGain;
    public int EnemyKilled;
    public int PointDegradation;
    private float PointInterval = 10f;    
    private float Timer;
    private Enemy_Hp Hp;
    private GameObject Player;
    private Player_Control Points;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Hp = GetComponent<Enemy_Hp>();
        Player = GameObject.FindWithTag("Player");
        Points = Player.GetComponent<Player_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Time.deltaTime;
        if(Timer > PointInterval)
        {
            PointGain -= PointDegradation;
        }
        if(Hp.Hp <= 0 && !hasRun)
        {
            Points.PointsGain(PointGain);Debug.Log("Points +");
            Points.enemyKilled++;
            hasRun = true;
        }
        
    }
}
