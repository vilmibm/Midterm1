using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public string type;

    public void Apply() {
        if (type == "LifeUp") {
            GameMaster gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            gameMaster.AddLife(1);
        } else if (type == "ExtendPaddle") {
            PlayerController pc = GameObject.Find("Paddle").GetComponent<PlayerController>();
            pc.Scale(2.0f);
            pc.Invoke("ResetSize", 6.0f);
        } else if (type == "ShrinkPaddle") {
            PlayerController pc = GameObject.Find("Paddle").GetComponent<PlayerController>();
            pc.Scale(0.5f);
            pc.Invoke("ResetSize", 6.0f);
        } else if (type == "SpeedUpBall") {
            BallController bc = GameObject.Find("Ball").GetComponent<BallController>();
            bc.ApplySpeedUp();
        } else if (type == "SlowDownBall") {
            BallController bc = GameObject.Find("Ball").GetComponent<BallController>();
            bc.ApplySlowDown();
        } else if (type == "MultiBall") {
            // TODO method on Ball that clones itself x3?
            // TODO need CloneBall prefix or can instantiate a ball and then clone?
                // - they need to be able to break bricks but not be able to die
            // TODO
        }
    }
}
