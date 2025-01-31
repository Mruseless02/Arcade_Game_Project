using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{

    public TMP_Text highScore;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        highScore.text = $"Highscore : {PlayerPrefs.GetInt("Highscore", 0)}";
    }
}
