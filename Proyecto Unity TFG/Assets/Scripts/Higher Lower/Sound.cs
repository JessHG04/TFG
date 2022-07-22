using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    [SerializeField] private AudioSource sound;
    [SerializeField] private int freq;

    public int getFreq() => freq;
    public bool isPlaying() => sound.isPlaying;

    public void playSound() {
        sound.PlayOneShot(sound.clip);
    }

    public void stopSound() {
        sound.Stop();
    }
}