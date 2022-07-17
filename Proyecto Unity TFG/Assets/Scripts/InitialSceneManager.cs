using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialSceneManager : MonoBehaviour {
          
    private void Update() {
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
    
    public void NinjaRunClicked() {
        SceneManager.LoadScene("NinjaRun", LoadSceneMode.Single);
    }

    public void HigherLowerClicked() {
        SceneManager.LoadScene("HigherLower", LoadSceneMode.Single);
    }

}