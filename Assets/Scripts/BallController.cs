using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballForce;
    public GameMaster gameMaster;
    private Rigidbody2D ballRb;
    private bool launched;
    private Vector2 startingPos;
    private bool speedModified;
    private float speedUpFactor;
    private float slowDownFactor;
    private int numClones;

    void Start() {
        numClones = 3;
        speedUpFactor = 4.0f;
        slowDownFactor = 2.0f;
        speedModified = false;
        ballRb = GetComponent<Rigidbody2D>();
        startingPos = transform.position;
        launched = false;
    }

    private void Reset() {
        StopAllCoroutines();
        ballRb.bodyType = RigidbodyType2D.Static;
        speedModified = false;
        launched = false;
        ballRb.velocity = new Vector2(0,0);
        transform.position = startingPos;
    }

    public void ApplySpeedUp() {
        if (speedModified) {
            return;
        }
        speedModified = true;
        ballRb.AddForce(speedUpFactor * ballRb.velocity, ForceMode2D.Impulse);
        StartCoroutine(SpeedUpModifierCooldown());
    }

    public IEnumerator SpeedUpModifierCooldown() {
        yield return new WaitForSeconds(5.0f);
        ResetSpeedUp();
    }

    public void ApplySlowDown() {
        if (speedModified) {
            return;
        }
        Debug.Log("farts");
        speedModified = true;
        ballRb.AddForce(-slowDownFactor * ballRb.velocity, ForceMode2D.Impulse);
        StartCoroutine(SlowDownModifierCooldown());
    }
    public IEnumerator SlowDownModifierCooldown() {
        yield return new WaitForSeconds(5.0f);
        ResetSlowDown();
    }

    public void ResetSpeedUp() {
        ballRb.AddForce(-(speedUpFactor/2) * ballRb.velocity, ForceMode2D.Impulse);
        speedModified = false;
    }

    public void ResetSlowDown() {
        ballRb.AddForce(slowDownFactor * 1.5f * ballRb.velocity, ForceMode2D.Impulse);
        speedModified = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !launched) {
            Launch();
        }
    }

    public void MakeClones() {
        for (int i = 0; i < numClones; i++) {
            BallController clone = Instantiate(this, transform.position, transform.rotation);
            clone.gameObject.tag = "BallClone";
            Rigidbody2D cloneRb = clone.gameObject.GetComponent<Rigidbody2D>();
            int dir = Random.Range(0,2);
            switch(dir) {
                case 0:
                    cloneRb.AddForce(new Vector2(0, ballForce), ForceMode2D.Impulse);
                    break;
                case 1:
                    cloneRb.AddForce(new Vector2(ballForce, ballForce), ForceMode2D.Impulse);
                    break;
                case 2:
                    cloneRb.AddForce(new Vector2(-ballForce, ballForce), ForceMode2D.Impulse);
                    break;
            }
        }
    }

    void Launch() {
        ballRb.bodyType = RigidbodyType2D.Dynamic;
        launched = true;
        int dir = Random.Range(0,2);
        switch(dir) {
            case 0:
                ballRb.AddForce(new Vector2(0, ballForce), ForceMode2D.Impulse);
                break;
            case 1:
                ballRb.AddForce(new Vector2(ballForce, ballForce), ForceMode2D.Impulse);
                break;
            case 2:
                ballRb.AddForce(new Vector2(-ballForce, ballForce), ForceMode2D.Impulse);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(gameObject.tag);
        if (!this.gameObject.CompareTag("Ball")) {
            return;
        }
        if (other.gameObject.tag == "KillPlane") {
            gameMaster.HandleBallDeath();
            Reset();
        }
    }
}
