using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballForce;
    private GameMaster gameMaster;
    public GameObject ballSpawnAnimation;
    private Rigidbody2D ballRb;
    private bool launched;
    private Vector2 startingPos;
    private bool speedModified;
    private float speedUpFactor;
    private float slowDownFactor;
    private int numClones;
    private SpriteRenderer spriteRenderer;
    private AudioController audioController;

    void Start() {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        numClones = 3;
        speedUpFactor = 4.0f;
        slowDownFactor = 2.0f;
        speedModified = false;
        ballRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingPos = transform.position;
        launched = false;
    }

    public void Reset() {
        StopAllCoroutines();
        ballRb.angularVelocity = 0.0f;
        ballRb.rotation = 0.0f;
        ballRb.bodyType = RigidbodyType2D.Static;
        speedModified = false;
        launched = false;
        Instantiate(ballSpawnAnimation, startingPos, Quaternion.identity);
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
        spriteRenderer.transform.RotateAround(transform.position, Vector3.forward, ballRb.rotation);

        if (Input.GetKeyDown(KeyCode.Space) && !launched && !gameObject.CompareTag("BallClone")) {
            Launch();
        }
    }

    public void MakeClones() {
        for (int i = 0; i < numClones; i++) {
            BallController clone = Instantiate(this, transform.position, transform.rotation);
            clone.gameObject.tag = "BallClone";
            SpriteRenderer cloneSpriteRenderer = clone.GetComponent<SpriteRenderer>();
            cloneSpriteRenderer.color = Color.gray;
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

    void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Brick")) {
            audioController.BallBounce();
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "KillPlane") {
            if (gameObject.CompareTag("BallClone")) {
                Destroy(gameObject);
            } else {
                gameMaster.HandleBallDeath();
                Reset();
            }
        }
    }
}
