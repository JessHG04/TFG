using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialSceneManager : MonoBehaviour {
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
