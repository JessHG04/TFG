using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            Handheld.Vibrate();
            LevelManager.getInstance().UpdateScore();
        }
    }
}
