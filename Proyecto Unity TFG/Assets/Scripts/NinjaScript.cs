using UnityEngine;
using UnityEngine.SceneManagement;

public class NinjaScript : MonoBehaviour {
    private int score = 0;
    public float JumpForce;
    [SerializeField]
    private bool isGrounded = false;
    private bool isAlive = true;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) {
            if(isGrounded){
                rb.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
                //Debug.Log("Jump");
            }
        }
        if(!isAlive){
            SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground") {
            if(!isGrounded) {
                isGrounded = true;
            }
        }
        if(collision.gameObject.tag == "Enemy") {
            //isAlive = false;
        }
    }
}