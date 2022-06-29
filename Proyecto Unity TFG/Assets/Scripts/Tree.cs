using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {
    public Transform treeTransform;
    public SpriteRenderer treeSpriteRenderer;
    public float treeMoveSpeed;

    public Transform getTransform() => treeTransform;
    public float getWidth() => treeSpriteRenderer.size.x;

    public void Move() {
        treeTransform.position += new Vector3(-1, 0, 0) * treeMoveSpeed * Time.deltaTime;
    }
}
