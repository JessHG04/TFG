using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour {
    public GameObject enemy;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float SpeedMultipler;
    private int currentEnemies = 0;
    private int maxEnemies = 5;

    private static EnemiesGenerator _instance;

    private void Awake() {
        currentSpeed = minSpeed;
        generateEnemy();
        _instance = this;
    }

    private void Start() {
        Enemy.GetInstance().OnCollisionNext += OnCollisionNext;
    }

    public static EnemiesGenerator GetInstance() {
        return _instance;
    }
    
    /*public void GenerateNextEnemy() {
        if(currentEnemies < maxEnemies) {
            //float randWait = Random.Range(0.5f, 1.2f);
            float randWait = 1.5f;
            Invoke("generateEnemy", randWait);    
        }
    }
    */

    private void OnCollisionNext(object sender, EventArgs e) {
        generateEnemy();
        //Enemy.GetInstance().OnCollisionNext -= OnCollisionNext;
        Enemy.GetInstance().OnCollisionNext += OnCollisionNext;
        Debug.Log("Genero enemigo");
    }
    
    public void generateEnemy(){
        GameObject EnemyInstance = Instantiate(enemy, transform.position, transform.rotation);
        //EnemyInstance.GetComponent<Enemy>().generator = this;
        currentEnemies++;
    }

    private void Update() {
        if(currentSpeed < maxSpeed){
            currentSpeed += SpeedMultipler;
        }
    }

    public void DecreaseEnemies() {
        currentEnemies--;
    }
}
