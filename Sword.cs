using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sword : Weapon {

    public SceneTransitions sceneTransitions;
    double musMod;

    void Awake() {
        musMod = 0;
    }

    public override int use(GameObject player, GameObject enemy) {
        int strMod = player.GetComponent<Character>().getStat(2);
        int defMod = enemy.GetComponent<Character>().getStat(3);
        if(player.GetComponent<Character>().checkIfPlayer()) {
            musMod = Math.Floor((double)sceneTransitions.getNotesFinished());
        } else {
            musMod = Math.Floor((double)0);
        }
        int totalDmg = -1 - strMod - (int)musMod + defMod; 
        if (totalDmg < 0) {
            enemy.GetComponent<Character>().changeHP(totalDmg);
        }
        if (player.GetComponent<Character>().checkIfPlayer()) {
            sceneTransitions.songDone3 = true;
        }
        return 1;
    }

    public override void musicLoader() {
        sceneTransitions.activeSword = true;
        base.musicLoader();
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneTransitions.activeSword && sceneTransitions.songDone2) {
            sceneTransitions.songDone2 = false;
            sceneTransitions.activeSword = false;
            sceneTransitions.getPlayer().GetComponent<Character>().setAllStats(sceneTransitions.playerStatsHold);
            sceneTransitions.getEnemy().GetComponent<Character>().setAllStats(sceneTransitions.enemyStatsHold);
            use(sceneTransitions.getPlayer(), sceneTransitions.getEnemy());
        }
    }
}
