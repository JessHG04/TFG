using UnityEngine;

public class Enemy : MonoBehaviour {
    public EnemiesGenerator generator;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update() {
        transform.Translate(Vector2.left * generator.currentSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="collision">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Next") {
            generator.GenerateNextEnemy();
        }
        if(collision.gameObject.tag == "Finish") {
            Destroy(this.gameObject);
        }
    }
}
