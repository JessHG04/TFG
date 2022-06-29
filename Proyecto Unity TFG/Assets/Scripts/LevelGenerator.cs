using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private Transform platformStart;
    [SerializeField] private Ninja ninja;
    [SerializeField] private List<GameObject> platformsTypes;
    [SerializeField] private List<Tree> frontTrees;
    [SerializeField] private List<Tree> midTrees;
    [SerializeField] private List<Tree> backTrees;
    private const float platformDestroyPositionX = -50f;
    private const float PlayerPlatformDistance = 40f;
    private List<Platform> platformList;
    private Vector3 lastEndPosition;
    private static LevelGenerator instance;
    private int score = 0;

    public static LevelGenerator getInstance(){
        return instance;
    }

    public int getScore() => score;

    private void Awake() {
        instance = this;
        lastEndPosition = platformStart.Find("EndPosition").position;
        platformList = new List<Platform>();
        platformList.Add((GameObject.Find("Platform_Start")).GetComponent<Platform>());
        SpawnPlatform();        
    }

    private void Update() {
        float distance = lastEndPosition.x - ninja.getPosition().x;
        if(ninja.getPosition().y < (-14)){
            
            //SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
        }
        else{
            if(distance < PlayerPlatformDistance){
                SpawnPlatform();
            }
            UpdatePlatforms();
            UpdateTrees();
        }
    }

    public void UpdateScore() {
        score++;
        //Debug.Log(score);
    }
    
    private void SpawnPlatform() {
        GameObject chosenPlatform;
        float ninjaPosY = ninja.getPosition().y;

        if(ninjaPosY < (-6)){   //Ninja abajo spawn plat 1 y 2
            //Debug.Log("Abajo");
            chosenPlatform = platformsTypes[Random.Range(0, 1)];
        }
        else if(ninjaPosY > 1.5){   //Ninja arriba spawn plat 2 y 3
            //Debug.Log("Arriba");
            chosenPlatform = platformsTypes[Random.Range(1, 2)];
        }
        else{   //Ninja en medio, spawn plat 1, 2 y 3
            //Debug.Log("Medio");
            chosenPlatform = platformsTypes[Random.Range(0, platformsTypes.Count)];
        }
        
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

    private void UpdateTrees(){
        for(int x = 0; x < frontTrees.Count; x++){
            frontTrees[x].Move();
        }

        for(int x = 0; x < midTrees.Count; x++){
            midTrees[x].Move();
        }

        for(int x = 0; x < backTrees.Count; x++){
            backTrees[x].Move();
        }
    }
}
