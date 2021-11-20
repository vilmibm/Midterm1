using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public float range = 10.0f;
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 10.0f;
    private Vector2 startPos;
    void Start() { 
        startPos = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    void Update() {
        Vector3 pos = transform.position;
        if (pos.x < startPos.x - range || pos.y < startPos.y - range || pos.x > startPos.x + range || pos.y > startPos.y + range) {
            direction = -direction;
        }
        transform.position = new Vector3(pos.x += direction.x * speed * Time.deltaTime, pos.y += direction.y * speed * Time.deltaTime, pos.z);
    }
}
