using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int hitValue;
    public LevelController lvlc;
    public GameMaster gameMaster;
    public int maxHP;
    private int hp;
    private SpriteRenderer sRenderer;

    void Start() {
        hp = maxHP;
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
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
