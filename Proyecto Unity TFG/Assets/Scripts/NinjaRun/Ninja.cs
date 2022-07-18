using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private bool isGrounded = false;
    [SerializeField] private float jumpForce;
    private AudioSource ninjaJump;
    public Vector3 getPosition() => transform.position;

    private void Awake() {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        ninjaJump = transform.GetComponent<AudioSource>();
    }

    private void Update() {
        if(isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)){
            rigidbody2d.velocity = Vector2.up*jumpForce;
            isGrounded = false;
            ninjaJump.PlayOneShot(ninjaJump.clip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Platform") {         //Layer 6 -> Platform
            if(!isGrounded) {
                isGrounded = true;
            }
        }
    }
}
