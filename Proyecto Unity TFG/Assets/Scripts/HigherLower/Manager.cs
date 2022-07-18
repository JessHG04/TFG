using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour {
    private static Manager instance;
    private int score = 0;
    private int oldHighScore = 0;
    [SerializeField] private List<Sound> soundsList;

    public static Manager getInstance() => instance;

    public int getScore() => score;

    private void Awake() {
        instance = this;
        //oldHighScore = PlayerPrefs.GetInt("Highscore");
    }

    private void Update() {
        for (int x = 0; x<soundsList.Count; x++){
            soundsList[x].playSound();
        }
    }

}