using UnityEngine;

public class EnemiesGenerator : MonoBehaviour {
    public GameObject enemy;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float SpeedMultipler;

    private void Awake() {
        currentSpeed = minSpeed;
        generateEnemy();
    }
    public void GenerateNextEnemy() {
        float randWait = Random.Range(0.1f, 1.2f);
        Invoke("generateEnemy", randWait);
    }
    private void generateEnemy(){
        GameObject EnemyInstance = Instantiate(enemy, transform.position, transform.rotation);
        EnemyInstance.GetComponent<Enemy>().generator = this;
    }

    private void Update() {
        if(currentSpeed < maxSpeed){
            currentSpeed += SpeedMultipler;
        }
    }
}
