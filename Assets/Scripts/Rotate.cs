using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float rotSpeed = 25.0f;

    void Update() {
        this.transform.RotateAround(this.transform.position, Vector3.forward, rotSpeed * Time.deltaTime);
    }
}
