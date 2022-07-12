using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Choco");
        if(other.gameObject.tag == "Player") {
            //Debug.Log("Aviso");
            Handheld.Vibrate();
            LevelManager.getInstance().UpdateScore();
        }
    }
}
