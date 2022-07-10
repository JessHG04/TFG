using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaScoreWindow : MonoBehaviour{
    private Text scoreText;
    private Text highscoreText;

    private void Awake() {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        highscoreText = transform.Find("HighscoreText").GetComponent<Text>();
    }

    private void Start() {
        highscoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
    
    private void Update() {
        scoreText.text = "Score: " + (LevelGenerator.getInstance().getScore()).ToString();
    }
}