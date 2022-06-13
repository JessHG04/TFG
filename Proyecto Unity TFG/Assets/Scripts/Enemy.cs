using UnityEngine;

public class Enemy : MonoBehaviour {
    public EnemiesGenerator generator;
    
    private void Update() {
        transform.Translate(Vector2.left * generator.currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Next") { 
            generator.generateEnemy();
        }

        if(collision.gameObject.tag == "Finish") {
            Destroy(this.gameObject);
            generator.DecreaseEnemies();
        }
    }
}
