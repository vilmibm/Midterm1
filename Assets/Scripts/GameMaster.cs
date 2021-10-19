using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {
    public int maxLives = 3;
    public PlayerController paddle;
    private int lives;
    void Start() {
        lives = maxLives;
    }

    public void HandleBallDeath() {
        lives--;
        if (lives == 0) {
            SceneManager.LoadScene("GameOver");
            return;
        }
        paddle.Reset();
    }

    void Update() { }
}
