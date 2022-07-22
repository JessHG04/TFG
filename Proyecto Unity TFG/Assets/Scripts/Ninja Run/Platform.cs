using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private const float PlatformMoveSpeed = 10.0f;
    public Transform ownTransform;
    public int type; 

    public Transform getPlatformTransform() => ownTransform;
    public int getType() => type;

    public void MoveToInitialPosition(Vector3 spawnPosition) {
        ownTransform.position = spawnPosition;
        if(type == 1){
            ownTransform.position = ownTransform.position + new Vector3(10 , 1, 0);
        }
        if(type == 2){
            ownTransform.position = ownTransform.position + new Vector3(10 , -1, 0);
        }
        if(type == 3){
            ownTransform.position = ownTransform.position + new Vector3(10 , -3, 0);
        }
    }

    public void Move(){
        ownTransform.position += new Vector3(-1, 0, 0) * PlatformMoveSpeed * Time.deltaTime;
    }

    public void DestroySelf(){
        Destroy(ownTransform.gameObject);
    }
    
}
