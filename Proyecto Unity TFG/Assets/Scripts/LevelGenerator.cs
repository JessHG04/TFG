using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject platformGO;
    [SerializeField] private Transform platformStart;
    [SerializeField] private Transform platform_1;
    private const float platformDestroyPositionX = -50f;
    private List<Platform> platformList;
    private Vector3 lastEndPosition;

    private void Awake() {
        Transform lastPlatformTransf;
        lastEndPosition = platformStart.Find("EndPosition").position;
        platformList = new List<Platform>();
        platformList.Add((GameObject.Find("Platform_Start")).GetComponent<Platform>());
        
        lastPlatformTransf = SpawnPlatform(platformStart.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf = SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf = SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf = SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf = SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
    }

    private void SpawnPlatform() {
        Transform lastPlatformTransf = SpawnPlatform(lastEndPosition);
        lastEndPosition = lastPlatformTransf.Find("EndPosition").position;
    }

    private Transform SpawnPlatform(Vector3 spawnPosition) {
        var plat = Instantiate(platformGO.GetComponent<Platform>());
        plat.getPlatformTransform().position = spawnPosition;
        platformList.Add(plat);
        return plat.getPlatformTransform();
    }

    private void Update() {
        UpdatePlatforms();
    }

    private void UpdatePlatforms() {
        for(int x = 0; x < platformList.Count; x++){
            if(platformList[x].getPlatformTransform().position.x <= platformDestroyPositionX){
                platformList[x].DestroySelf();
                platformList.Remove(platformList[x]);
            }else{
                platformList[x].Move();
            }
            
        }
    }
}
