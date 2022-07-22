using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour {
    private static Manager instance;
    private int round = 0;
    private int maxRounds;
    private int scoreRound = 1;
    private int oldHighScore;
    [SerializeField] private List<Sound> soundsList;
    [SerializeField] private List<Sound> voiceList;

    public static Manager getInstance() => instance;

    public int getScoreRound() => scoreRound;

    private void Awake() {
        instance = this;
        Vibration.Init();
        maxRounds = soundsList.Count - 1;
        oldHighScore = PlayerPrefs.GetInt("HighscoreHG");
        if(oldHighScore == 0){
            PlayerPrefs.SetInt("HighscoreHG", 1);
            PlayerPrefs.Save();
        }
        oldHighScore = PlayerPrefs.GetInt("HighscoreHG");
        Invoke("shuffle", 14.0f);
    }

    private void shuffle() {
        int randomIndex = Random.Range(0, soundsList.Count -1);
        Sound snd;
        int it = 0;
        
        while(it < 3){
            for(int x = 0; x < soundsList.Count; x++){
                snd = soundsList[x];
                soundsList[x] = soundsList[randomIndex];
                soundsList[randomIndex] = snd;
            }
            it++;
        }
        playFirstSound();
    }

    public void UpdateScore() {
        if(scoreRound != maxRounds){
            scoreRound++;
        }
        if(scoreRound > oldHighScore){
            PlayerPrefs.SetInt("HighscoreHG", scoreRound);
            PlayerPrefs.Save();
        }
    }

    public void HighClicked() {
        int nextRound = round + 1;
        soundsList[round].stopSound();
        soundsList[nextRound].stopSound();
        if(soundsList[nextRound].getFreq() > soundsList[round].getFreq()){
            UpdateScore();
            round++;
            if(round < maxRounds){
                playFirstSound();
            }
            else{
                Vibration.Cancel();
                playEndGame();
            }
        }
        else{
            Vibration.Cancel();
            playEndGame();
        }
    }

    public void LowClicked() {
        int nextRound = round + 1;
        soundsList[round].stopSound();
        soundsList[nextRound].stopSound();
        if(soundsList[nextRound].getFreq() < soundsList[round].getFreq()){
            UpdateScore();
            round++;
            if(round < maxRounds){
                playFirstSound();
            }
            else{
                Vibration.Cancel();
                playEndGame();
            }
        }
        else{
            Vibration.Cancel();
            playEndGame();
        }
    }

    private void playFirstSound() {
        int ms = soundsList[round].getFreq();
        int sec = (ms / 1000) + 1;
        Vibration.Vibrate(ms); //Miliseconds
        soundsList[round].playSound();
        Invoke("playSecondSound", sec); //Seconds
    }

    private void playSecondSound() {
        Vibration.Vibrate(soundsList[round + 1].getFreq()); //Miliseconds
        soundsList[round + 1].playSound();
    }

    private void playEndGame() {        
        if(scoreRound == maxRounds){
            Invoke("returnToMenu", 3.5f);
            if(!voiceList[0].isPlaying()){
                voiceList[0].playSound();
            }
        }
        else if(scoreRound > oldHighScore){
            Invoke("returnToMenu", 2.0f);
            if(!voiceList[1].isPlaying()){
                voiceList[1].playSound();
            }
        }
        else{
            Invoke("returnToMenu", 2.75f);
            if(!voiceList[2].isPlaying()){
                voiceList[2].playSound();
            }
        }
    }

    private void returnToMenu() {
        SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
    }
}