using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
    public int numDebris = 4;
    public float minUpForce = 0.5f;
    public float maxUpForce = 2.0f;
    public float minSideForce = 0.5f;
    public float maxSideForce = 2.0f;
    public GameObject debrisPrefab;
    private BrickController brickController;

    void Start() { 
        brickController = gameObject.GetComponent<BrickController>();
    }

    void Update() {
        if (brickController.hp > 0) {
            return;
        }
        // TODO figure out how to hide the sprite so it can still 
        //      be destroyed by LateUpdate in bc
        for (int i = 0; i < numDebris; i++) { 
            GameObject debris = Instantiate(debrisPrefab, transform.position, transform.rotation);
            Rigidbody2D debrisRb = debris.GetComponent<Rigidbody2D>();

            debrisRb.AddForce(Vector2.up * Random.Range(minUpForce, maxUpForce), ForceMode2D.Impulse);
            if (Random.Range(0,2) == 0) {
                debrisRb.AddForce(Vector2.left * Random.Range(minSideForce, maxSideForce), ForceMode2D.Impulse);
            } else {
                debrisRb.AddForce(Vector2.right * Random.Range(minSideForce, maxSideForce), ForceMode2D.Impulse);
            }
        }
    }
}
