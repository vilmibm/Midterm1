using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesList : MonoBehaviour {
    public GameObject life;
    public GameObject addAnimation;
    public GameObject removeAnimation;
    private float spriteWidth;
    private List<GameObject> lives;
    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = life.GetComponent<SpriteRenderer>().bounds.size.x;
        lives = new List<GameObject>();
    }

    public void AddLife() {
        float x = (transform.position.x - spriteRenderer.bounds.size.x/2)  + (spriteWidth * lives.Count) + spriteWidth;
        GameObject newLife = Instantiate(life, new Vector2(x, transform.position.y), Quaternion.identity);
        newLife.transform.parent = this.gameObject.transform;
        Instantiate(addAnimation, newLife.transform.position, Quaternion.identity);
        lives.Add(newLife);
    }

    public void RemoveLife() {
        int last = lives.Count-1;
        GameObject toDestroy = lives[last];
        Vector2 pos = new Vector2(toDestroy.transform.position.x, toDestroy.transform.position.y+0.05f);
        Instantiate(removeAnimation, pos, Quaternion.identity);
        lives.RemoveAt(last);
        Destroy(toDestroy);
    }
}
