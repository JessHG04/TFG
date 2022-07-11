using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private bool isGrounded = false;
    [SerializeField] private float jumpForce;
    //[SerializeField] private LayerMask platformLayer;
    private AudioSource ninjaJump;
    public Vector3 getPosition() => transform.position;

    private void Awake() {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        ninjaJump = transform.GetComponent<AudioSource>();
    }

    private void Update() {
        if(isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)){
            //Debug.Log("Jump");
            rigidbody2d.velocity = Vector2.up*jumpForce;
            isGrounded = false;
            ninjaJump.PlayOneShot(ninjaJump.clip);
        }
    }

    /*private bool isGrounded() {
        RaycastHit2D raycastHit2d =  Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0, Vector2.down, 5f, platformLayer);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }*/

    private void OnCollisionEnter2D(Collision2D collision) {
        //Layer 6 -> Platform
        if(collision.gameObject.tag == "Platform") {
            if(!isGrounded) {
                isGrounded = true;
            }
        }
        if(collision.gameObject.tag == "Enemy") {
            //isAlive = false;
        }
    }
}
