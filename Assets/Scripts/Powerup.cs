using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public string type;
    private BallController ballController;
    private PlayerController playerController;
    private GameMaster gameMaster;
    private AudioController audioController;

    public void Start() {
        ballController = GameObject.Find("Ball").GetComponent<BallController>();
        playerController = GameObject.Find("Paddle").GetComponent<PlayerController>();
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    public void Apply() {
        if (type == "LifeUp") {
            gameMaster.AddLife(1);
        } else if (type == "ExtendPaddle") {
            audioController.PaddleExtend();
            playerController.Scale(2.0f);
            playerController.Invoke("ResetSize", 6.0f);
        } else if (type == "ShrinkPaddle") {
            audioController.PaddleShrink();
            PlayerController pc = GameObject.Find("Paddle").GetComponent<PlayerController>();
            pc.Scale(0.5f);
            pc.Invoke("ResetSize", 6.0f);
        } else if (type == "SpeedUpBall") {
            audioController.BallSpeedUp();
            ballController.ApplySpeedUp();
        } else if (type == "SlowDownBall") {
            audioController.BallSpeedDown();
            ballController.ApplySlowDown();
        } else if (type == "MultiBall") {
            audioController.MultiBall();
            ballController.MakeClones();
        }
    }
}
