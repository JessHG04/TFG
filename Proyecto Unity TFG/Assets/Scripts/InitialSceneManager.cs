using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialSceneManager : MonoBehaviour {
    public int target = 30;
      
    private void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
      
    private void Update() {
        if(Application.targetFrameRate != target){
            Application.targetFrameRate = target;
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
