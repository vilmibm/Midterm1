using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    public int maxLives = 3;
    public PlayerController paddle;
    private int lives;
    private GameObject[] bricks;
    private AudioController audioController;
    private LivesList livesList;
    void Start() {
        lives = maxLives;
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        livesList = GameObject.Find("LivesList").GetComponent<LivesList>();
        for (int i = 0; i < lives; i++) {
            // TODO less liveList to add a life
            livesList.AddLife();
        }
    }
    public void AddLife(int howMany) {
        audioController.LifeUp();
        livesList.AddLife();
        lives += howMany;
    }

    public void HandleBallDeath() {
        audioController.LifeLost();
        lives--;
        if (lives == 0) {
            SceneManager.LoadScene("GameOver");
            return;
        }
        livesList.RemoveLife();
        paddle.Reset();
    }

    void Update() {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        if (bricks.Length == 0 && lives > 0) { // probably over-defensive here
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
