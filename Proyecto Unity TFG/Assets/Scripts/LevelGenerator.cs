using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public GameObject platformGO;
    [SerializeField] private Transform Platform_1;
    private List<Platform> platformList;

    private void Awake() {
        platformList = new List<Platform>();
        SpawnPlatform(new Vector3(18, -6));
        SpawnPlatform(new Vector3(18, -3) + new Vector3(10, 0)) ;
        SpawnPlatform(new Vector3(18, -0) + new Vector3(20, 0)) ;
    }

    private void SpawnPlatform(Vector3 spawnPosition) {
        var plat = Instantiate(platformGO.GetComponent<Platform>());
        plat.getPlatformTransform().position = spawnPosition;
        platformList.Add(plat);
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
