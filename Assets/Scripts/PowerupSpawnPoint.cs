using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawnPoint : MonoBehaviour {
    public Powerup[] possiblePowerups;
    public float spawnIntervalMin;
    public float spawnIntervalMax;

    void Start() {
        SpawnPowerup();
    }

    void SpawnPowerup() {
        if (transform.childCount == 0) {
            Powerup powerupPrefab = possiblePowerups[Random.Range(0, possiblePowerups.Length)];
            Powerup child = Instantiate(powerupPrefab, transform.position, transform.rotation);
            child.transform.parent = transform;
        }

        float delay = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Invoke("SpawnPowerup", delay);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Ball")) {
            return;
        }
        if (transform.childCount == 0) {
            return;
        }
        Powerup child = transform.GetChild(0).GetComponent<Powerup>();
        child.Apply();
        Destroy(child.gameObject);
    }
}
