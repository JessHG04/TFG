using UnityEngine;

public class EnemiesGenerator : MonoBehaviour {
    public GameObject enemy;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float SpeedMultipler;
    private int currentEnemies = 0;
    private int maxEnemies = 5;

    private void Awake() {
        currentSpeed = minSpeed;
        generateEnemy();
    }
    public void GenerateNextEnemy() {
        if(currentEnemies < maxEnemies) {
            float randWait = Random.Range(0.5f, 1.2f);
            Invoke("generateEnemy", randWait);    
        }
    }
    private void generateEnemy(){
        GameObject EnemyInstance = Instantiate(enemy, transform.position, transform.rotation);
        EnemyInstance.GetComponent<Enemy>().generator = this;
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
