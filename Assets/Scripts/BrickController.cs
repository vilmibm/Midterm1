using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int hitValue;
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
        Debug.Log("TODO add points " + hitValue);
        hp--;
    }
}
