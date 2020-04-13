using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public static int score;
    Text scoreText;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + score;    
    }
}
