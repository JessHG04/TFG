using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject platformGO;
    [SerializeField] private Transform platformStart;
    [SerializeField] private Transform platform_1;
    private List<Platform> platformList;

    private void Awake() {
        Transform lastPlatformTransf;
        platformList = new List<Platform>();
        lastPlatformTransf =  SpawnPlatform(platformStart.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf =  SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf =  SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf =  SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
        lastPlatformTransf =  SpawnPlatform(lastPlatformTransf.Find("EndPosition").position);
        lastPlatformTransf.position = lastPlatformTransf.position + new Vector3(10, 1, 0);
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
        foreach (Platform platform in platformList) {
            platform.Move();
        }
    }
}
