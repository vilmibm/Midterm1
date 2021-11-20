using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int hitValue;
    private LevelController lvlc;
    public int maxHP;
    public int hp;
    private SpriteRenderer sRenderer;

    void Start() {
        GameObject levelController = GameObject.Find("LevelController");
        lvlc = levelController.GetComponent<LevelController>();
        hp = maxHP;
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate() {
        if (hp == 1) {
            sRenderer.color = Color.white;
        }
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        lvlc.AddScore(hitValue);
        hp--;
    }
}
