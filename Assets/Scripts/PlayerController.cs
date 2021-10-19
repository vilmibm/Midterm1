using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public float speed = 10.0f;
  private float horizontalInput;

  private ContactPoint2D[] contacts;

  private bool lockLeft;
  private bool lockRight;
  private Vector2 startPos;

  void Start() {
    startPos = transform.position;
    lockLeft = true;
    lockRight = true;
    contacts = new ContactPoint2D[2];
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && (lockLeft && lockRight)) {
      lockLeft = false;
      lockRight = false;
    }
    horizontalInput = Input.GetAxis("Horizontal");
    if (lockLeft && horizontalInput < 0) {
      return;
    }
    if (lockRight && horizontalInput > 0) {
      return;
    }
    transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag != "Wall") {
      return;
    }
    other.GetContacts(contacts);
    if (contacts[0].point.x  < 0) {
      lockLeft = true;
      lockRight = false;
    } else {
      lockLeft = false;
      lockRight = true;
    }
  }

  private void OnCollisionExit2D(Collision2D other) {
    if (other.gameObject.tag != "Wall") {
      return;
    }
    lockLeft = false;
    lockRight = false;
  }

  public void Reset() {
    transform.position = startPos;
  }
}
