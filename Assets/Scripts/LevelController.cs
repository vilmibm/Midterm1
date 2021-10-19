using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public int score;

    void Start() {
        score = 0;
    }

    void Update() { }

    public void AddScore(int value) {
        score += value;
    }
}
