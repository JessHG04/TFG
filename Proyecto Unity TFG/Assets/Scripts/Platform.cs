using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private const float PlatformMoveSpeed = 10.0f;
    public Transform ownTransform;

    public Transform getPlatformTransform() => ownTransform;

    public void Move(){
        ownTransform.position += new Vector3(-1, 0, 0) * PlatformMoveSpeed * Time.deltaTime;
    }

    public void DestroySelf(){
        Destroy(ownTransform.gameObject);
    }
    
}
