using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip ballSpeedDown;
    public AudioClip ballSpeedUp;
    public AudioClip paddleExtend;
    public AudioClip paddleShrink;
    public AudioClip lifeUp;
    public AudioClip lostLife;
    public AudioClip multiBall;
    public AudioClip explosion;
    public AudioClip ballBounce;
    public AudioClip brickBreak;
    public AudioClip brickHit;

    void Start() { 
        audioSource = GetComponent<AudioSource>();
    }

    public void LifeLost() {
        audioSource.PlayOneShot(lostLife);
    }

    public void LifeUp() {
        audioSource.PlayOneShot(lifeUp);
    }

    public void MultiBall() {
        audioSource.PlayOneShot(multiBall);
    }

    public void PaddleExtend() {
        audioSource.PlayOneShot(paddleExtend);
    }
    public void PaddleShrink() {
        audioSource.PlayOneShot(paddleShrink);
    }

    public void BallSpeedDown() {
        audioSource.PlayOneShot(ballSpeedDown);
    }

    public void BallSpeedUp() {
        audioSource.PlayOneShot(ballSpeedUp);
    }

    public void BallBounce() {
        audioSource.PlayOneShot(ballBounce, 0.75f);
    }

    public void BrickBreak() {
        audioSource.PlayOneShot(brickBreak);
    }

    public void BrickHit() {
        audioSource.PlayOneShot(brickHit, 0.75f);
    }

    public void Explosion() {
        audioSource.PlayOneShot(explosion);
    }
}
