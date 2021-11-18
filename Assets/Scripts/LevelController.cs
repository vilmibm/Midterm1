using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    public int score;
    public Text scoreText;

    void Start() {
        scoreText = GameObject.Find("ScoreUI").GetComponent<Text>();
        score = 0;
    }

    void Update() { }

    public void AddScore(int value) {
        score += value;
        scoreText.text = string.Format("Score: {0}", score);
    }
}
