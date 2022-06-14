using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //public EnemiesGenerator generator;
    public event EventHandler OnCollisionNext;

    private static Enemy _instance;

    private void Awake() {
        _instance = this;
    }

    public static Enemy GetInstance() {
        return _instance;
    }
    
    private void Update() {
        transform.Translate(Vector2.left * EnemiesGenerator.GetInstance().currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Next") { 
            //generator.generateEnemy();
            //Debug.Log(OnCollisionNext);
            if(OnCollisionNext != null) {
                OnCollisionNext(this, EventArgs.Empty);
            }
        }

        if(collision.gameObject.tag == "Finish") {
            Destroy(this.gameObject);
            //generator.DecreaseEnemies();
            EnemiesGenerator.GetInstance().DecreaseEnemies();
        }
    }
}
