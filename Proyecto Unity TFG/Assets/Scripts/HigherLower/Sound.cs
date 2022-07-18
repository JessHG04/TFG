using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    [SerializeField] private AudioSource sound;
    [SerializeField] private int freq;

    public int getFreq() => freq;
    //public int getSoundLength() => Mathf.RoundToInt(sound.clip.length);

    public void playSound() {
        //sound.PlayOneShot(sound.clip);
        //Debug.Log("playSound");
        sound.PlayOneShot(sound.clip);
    }
}