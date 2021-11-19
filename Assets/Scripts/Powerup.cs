using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public string type;

    public void Apply() {
        if (type == "LifeUp") {
            GameMaster gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            gameMaster.AddLife(1);
        }
    }
}
