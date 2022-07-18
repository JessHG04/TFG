using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    [SerializeField] private AudioSource sound;

    public void playSound() {
        //sound.PlayOneShot(sound.clip);
        Debug.Log("playSound");
        sound.PlayOneShot(sound.clip);
    }
}