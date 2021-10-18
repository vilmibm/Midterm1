using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
    public int maxLives = 3;
    public GameObject paddle;
    private int lives;
    void Start() {
        lives = maxLives;
    }

    public void HandleBallDeath() {
        lives--;
        if (lives == 0) {
            SceneManager.LoadScene("GameOver");
        }
    //    paddle.Reset();
    }

    void Update() { }
}
