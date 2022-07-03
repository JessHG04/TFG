using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private Transform platformStart;
    [SerializeField] private Ninja ninja;
    [SerializeField] private List<GameObject> platformsTypes;
    [SerializeField] private List<Tree> frontTrees;
    [SerializeField] private List<Tree> midTrees;
    [SerializeField] private List<Tree> backTrees;
    private const float platformDestroyPositionX = -50f;
    private const float playerPlatformDistance = 20f;
    private const float CameraOrtoSize = 10f;
    private const float treeMovePositionX = -40f;
    private List<Platform> platformList;
    private Vector3 lastEndPosition;
    private static LevelGenerator instance;
    private int score = 0;

    public static LevelGenerator getInstance(){
        return instance;
    }

    public int getScore() => score;

    private void Awake() {
        //Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);
        instance = this;
        lastEndPosition = platformStart.Find("EndPosition").position;
        platformList = new List<Platform>();
        platformList.Add((GameObject.Find("Platform_Start")).GetComponent<Platform>());
        SpawnPlatform();        
    }

    private void Update() {
        float distance = lastEndPosition.x - ninja.getPosition().x;
        if(ninja.getPosition().y < (-14)){
            SceneManager.LoadScene("InitialScene", LoadSceneMode.Single);
            setHighscore();
        }
        else{
            if(distance < playerPlatformDistance){
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

        if(ninjaPosY <= (-6)){   //Ninja abajo spawn plat 1 y 2
            //Debug.Log("Abajo");
            chosenPlatform = platformsTypes[Random.Range(1, 2)];
        }
        else if(ninjaPosY >= 2.5){   //Ninja arriba spawn plat 2 y 3
            //Debug.Log("Arriba");
            chosenPlatform = platformsTypes[Random.Range(2, 5)];
            //chosenPlatform = platformsTypes[2];
        }
        else{   //Ninja en medio, spawn plat 1, 2 y 3
            //Debug.Log("Medio");
            chosenPlatform = platformsTypes[Random.Range(1, 4)];
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

            if(frontTrees[x].getTransform().position.x < treeMovePositionX) {
                float rightMostPositionX = CameraOrtoSize * 2.0f;                                   // The right most position of the game screen
                for(int y = 0; y < frontTrees.Count; y++){
                    if(frontTrees[y].getTransform().position.x > rightMostPositionX){
                        rightMostPositionX = frontTrees[y].getTransform().position.x;
                    }
                }
                //Debug.Log(rightMostPositionX);
                //Move the ground to the right most position
                frontTrees[x].getTransform().position = new Vector3(rightMostPositionX + 40, frontTrees[x].getTransform().position.y, -2.0f);
            }
        }

        for(int x = 0; x < midTrees.Count; x++){
            midTrees[x].Move();

            if(midTrees[x].getTransform().position.x < treeMovePositionX) {
                float rightMostPositionX = CameraOrtoSize * 2.0f;                                   // The right most position of the game screen
                for(int y = 0; y < midTrees.Count; y++){
                    if(midTrees[y].getTransform().position.x > rightMostPositionX){
                        rightMostPositionX = midTrees[y].getTransform().position.x;
                    }
                }
                //Move the ground to the right most position
                midTrees[x].getTransform().position = new Vector3(rightMostPositionX + 40, midTrees[x].getTransform().position.y, -1.0f);
            }
        }

        for(int x = 0; x < backTrees.Count; x++){
            backTrees[x].Move();

            if(backTrees[x].getTransform().position.x < treeMovePositionX) {
                float rightMostPositionX = CameraOrtoSize * 2.0f;                                   // The right most position of the game screen
                for(int y = 0; y < backTrees.Count; y++){
                    if(backTrees[y].getTransform().position.x > rightMostPositionX){
                        rightMostPositionX = backTrees[y].getTransform().position.x;
                    }
                }
                //Move the ground to the right most position
                backTrees[x].getTransform().position = new Vector3(rightMostPositionX + 40, backTrees[x].getTransform().position.y, 0.0f);
            }
        }
    }

    public int getHighscore() {
        return PlayerPrefs.GetInt("Highscore");
    }

    public void setHighscore() {
        int oldScore = getHighscore();
        if(score > oldScore){
            PlayerPrefs.SetInt("Highscore", score);
            PlayerPrefs.Save();
        }
    }
}
