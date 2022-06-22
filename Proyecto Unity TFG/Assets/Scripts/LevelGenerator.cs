using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private Transform platformStart;
    [SerializeField] private Ninja ninja;
    [SerializeField] private List<GameObject> platformsTypes;
    private const float platformDestroyPositionX = -50f;
    private const float PlayerPlatformDistance = 50f;
    private List<Platform> platformList;
    private Vector3 lastEndPosition;

    private void Awake() {
        lastEndPosition = platformStart.Find("EndPosition").position;
        platformList = new List<Platform>();
        platformList.Add((GameObject.Find("Platform_Start")).GetComponent<Platform>());
        SpawnPlatform();        
    }

    private void Update() {
        float distance = lastEndPosition.x - ninja.getPosition().x;
        if(distance < PlayerPlatformDistance){
            SpawnPlatform();
        }
        UpdatePlatforms();
    }
    
    private void SpawnPlatform() {
        GameObject chosenPlatform = platformsTypes[Random.Range(0, platformsTypes.Count)];
        //GameObject chosenPlatform = platformsTypes[1];
        Transform lastPlatformTransf = SpawnPlatform(chosenPlatform, lastEndPosition);
        lastEndPosition = lastPlatformTransf.Find("EndPosition").position;
    }

    private Transform SpawnPlatform(GameObject platform, Vector3 spawnPosition) {
        var plat = Instantiate(platform.GetComponent<Platform>());
        plat.MoveToInitialPosition(spawnPosition);
        platformList.Add(plat);
        return plat.getPlatformTransform();
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
        lastEndPosition = platformList[platformList.Count - 1].getPlatformTransform().Find("EndPosition").position;
    }
}
