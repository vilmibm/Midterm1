using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballForce = 500f;
    public GameMaster gameMaster;
    private Rigidbody2D ballRb;
    private bool launched;
    private Vector2 startingPos;

    void Start() {
        Debug.Log("WTF");
        Debug.Log(transform.position);
        ballRb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        launched = false;
    }

    public void Reset() {
        launched = false;
        ballRb.velocity = new Vector2(0,0);
        transform.position = startingPos;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !launched) {
            Launch();
        }
    }

    void Launch() {
        launched = true;
        int dir = Random.Range(0,2);
        switch(dir) {
            case 0:
                ballRb.AddForce(Vector2.up * ballForce);
                break;
            case 1:
                ballRb.AddForce(Vector2.up * ballForce);
                ballRb.AddForce(Vector2.right * ballForce);
                break;
            case 2:
                ballRb.AddForce(Vector2.up * ballForce);
                ballRb.AddForce(Vector2.left * ballForce);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "KillPlane") {
            gameMaster.HandleBallDeath();
            Reset();
        }
    }
}
