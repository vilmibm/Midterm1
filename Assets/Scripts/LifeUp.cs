using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour {
    private GameMaster gameMaster;

    void Start() {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Apply() {
        gameMaster.AddLife(1);
    }
}
