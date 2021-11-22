using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAtCollision : MonoBehaviour {
    public GameObject spriteAnimation;

    void OnCollisionEnter2D(Collision2D other) {
        ContactPoint2D[] contacts = new ContactPoint2D[1];
        other.GetContacts(contacts);
        Instantiate(spriteAnimation, new Vector3(contacts[0].point.x, contacts[0].point.y, 0), Quaternion.identity);
    }
}
