using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int hitValue;
    public LevelController lvlc;
    public int maxHP;
    private int hp;

    void Start() {
        hp = maxHP;
    }

    void Update() {
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        lvlc.AddScore(hitValue);
        hp--;
    }
}
