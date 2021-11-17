using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void HowToPlay() {
        // TODO what to do here? load an interactive scene? SetActive a graphic?
        Debug.Log("TODO HOW TO PLAY");
    }
}
