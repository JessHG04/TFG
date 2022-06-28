using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour {
        
        private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            //Debug.Log("Aviso");
            Handheld.Vibrate();
            LevelGenerator.getInstance().UpdateScore();
        }
    }
}
