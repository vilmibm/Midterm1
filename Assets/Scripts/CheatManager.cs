using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatManager : MonoBehaviour {
    private BallController ballController;
    private PlayerController playerController;

    void Start() {
        GameObject ball = GameObject.Find("Ball");
        if (ball != null) {
            ballController = ball.GetComponent<BallController>();
        }
        GameObject paddle = GameObject.Find("Paddle");
        if (paddle != null) {
            playerController = paddle.GetComponent<PlayerController>();
        }
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.R)) {
            ballController.Reset();
            playerController.Reset();
        } else if (Input.GetKeyUp(KeyCode.N)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        } else if (Input.GetKeyUp(KeyCode.G)) {
            SceneManager.LoadScene("GameOver");
        } else if (Input.GetKeyUp(KeyCode.H)) {
            SceneManager.LoadScene("TitleScene");
        } else if (Input.GetKeyUp(KeyCode.Y)) {
            SceneManager.LoadScene("GameWon");
        } else if (Input.GetKeyUp(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
