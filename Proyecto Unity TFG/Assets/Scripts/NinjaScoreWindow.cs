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
    
    private void Update() {
        scoreText.text = "Puntuación: " + (LevelManager.getInstance().getScore()).ToString();
        highscoreText.text = "Récord: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
}