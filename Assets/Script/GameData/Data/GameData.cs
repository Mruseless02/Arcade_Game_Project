using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string Scene;
    public int PointCount;
    public int HpCount;
    public Vector3 playerPosition;
    public GameData() 
    {
        this.HpCount = 0;
        this.PointCount = 0;
        playerPosition = Vector3.zero;
    }
    
}
