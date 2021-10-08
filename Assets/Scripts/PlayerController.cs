using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public float speed = 10.0f;
  private float horizontalInput;
  void Start() { }

  void Update() {
    horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
  }
}
