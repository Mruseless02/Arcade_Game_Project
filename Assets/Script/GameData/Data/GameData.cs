using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string Scene;
    public int PointCount;
    public int enemyKilledCount;
    public int keyCount;
    public int HpCount;
    public GameData() 
    {
        this.enemyKilledCount = 0;
        this.Scene = "";
        this.HpCount = 0;
        this.PointCount = 0;
    }
    
}
