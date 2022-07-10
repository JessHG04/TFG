using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialSceneManager : MonoBehaviour {
    //public int target = 60;
      
    private void Awake() {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = target;
        //Screen.SetResolution(1920, 1080, FullScreenMode.ExclusiveFullScreen, 60);
    }
      
    private void Update() {
        /*if(Application.targetFrameRate != target){
            Application.targetFrameRate = target;
        }*/
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
    
    public void NinjaRunClicked() {
        //Play Sound Effect
        SceneManager.LoadScene("NinjaRun", LoadSceneMode.Single);
    }

    public void HigherLowerClicked() {
        //Play Sound Effect
        SceneManager.LoadScene("HigherLower", LoadSceneMode.Single);
    }

    public void ExitButtonClicked() {
        //Play Sound Effect
        Application.Quit();
    }
}
