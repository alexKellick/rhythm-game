using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item {
    public int effectValue;
    public int originalAmnt;
        void Start() {}

    void Awake() {
        amnt = 3;
    }

    public override int use(GameObject player, GameObject enemy) {
        if(amnt > 0){
            amnt -= 1;
            return effectValue;
        } else {
            Debug.Log("Out of uses! " + amnt);
            return 0;
        }
    }

    public override void musicLoader() {
        base.musicLoader();
    }
}
