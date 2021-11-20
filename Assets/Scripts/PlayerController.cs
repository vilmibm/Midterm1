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
  private float startingWidth;
  private bool extended;

  void Start() {
    extended = false;
    startingWidth = transform.localScale.x;
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
    lockLeft = true;
    lockRight = true;
  }

  public void Scale(float scale) {
    if (extended) {
      return;
    }
    extended = true;
    Vector3 s = this.transform.localScale;
    this.transform.localScale = new Vector3(s.x*scale, s.y, s.z);
  }

  public void ResetSize() {
    extended = false;
    Vector3 s = this.transform.localScale;
    this.transform.localScale = new Vector3(startingWidth, s.y, s.z);
  }
}
