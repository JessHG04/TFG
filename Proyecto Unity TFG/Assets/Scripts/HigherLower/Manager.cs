using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Manager : MonoBehaviour {
    private static Manager instance;
    private int round = 0;
    private int maxRounds;
    private int score = 0;
    private int oldHighScore = 0;
    [SerializeField] private List<Sound> soundsList;

    public static Manager getInstance() => instance;

    public int getScore() => score;

    private void Awake() {
        instance = this;
        Vibration.Init();
        maxRounds = soundsList.Count - 1;
        Debug.Log(maxRounds);
        //oldHighScore = PlayerPrefs.GetInt("Highscore");
        shuffle();
        playFirstSound();
    }

    private void shuffle() {
        int randomIndex = Random.Range(0, soundsList.Count -1);
        Sound snd;
        int it = 0;
        
        while(it < 2){
            for(int x = 0; x < soundsList.Count; x++){
                snd = soundsList[x];
                soundsList[x] = soundsList[randomIndex];
                soundsList[randomIndex] = snd;
            }
            it++;
        }
    }

    public void HighClicked() {
        int nextRound = round + 1;
        if(soundsList[nextRound].getFreq() > soundsList[round].getFreq()){
            Debug.Log("Acierto");
            score++;
        }
        else{
            Debug.Log("Fallo");
            Vibration.Cancel();
            returnToMenu();
        }
        round++;
        if(round < maxRounds){
            playFirstSound();
        }
        else{
            Debug.Log("Fin del juego");
            Vibration.Cancel();
            returnToMenu();
        }
    }

    public void LowClicked() {
        int nextRound = round + 1;
        if(soundsList[nextRound].getFreq() < soundsList[round].getFreq()){
            Debug.Log("Acierto");
            score++;
        }
        else{
            Debug.Log("Fallo");
            Vibration.Cancel();
            returnToMenu();
        }
        round++;
        if(round < maxRounds){
            playFirstSound();
        }
        else{
            Debug.Log("Fin del juego");
            Vibration.Cancel();
            returnToMenu();
        }
    }

    private void playFirstSound() {
        int ms = soundsList[round].getFreq();
        int sec = ms / 1000;
        Vibration.Vibrate(ms); //Miliseconds
        soundsList[round].playSound();
        Invoke("playSecondSound", sec); //Seconds
    }

    private void playSecondSound() {
        Vibration.Vibrate(soundsList[round].getFreq()); //Miliseconds
        soundsList[round + 1].playSound();
    }

    /*private void playEndGame() {
        playAudio.Pause();
        if(score > oldHighScore){
            Invoke("returnToMenu", 2.0f);
            if(!playAudio.isPlaying){
                playAudio.clip = newHighscore;
                playAudio.Play();
            }
        }
        else{
            Invoke("returnToMenu", 2.75f);
            if(!playAudio.isPlaying){
                playAudio.clip = noHighscore;
                playAudio.Play();
            }
        }
    }*/

    private void returnToMenu() {
        SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
    }
}