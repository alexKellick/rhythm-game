using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion {
    public SceneTransitions sceneTransitions;
    void Start() {}

 
    public override int use(GameObject player, GameObject enemy) {
        int hpMod = base.use(player, enemy);
        if (amnt > 0) {
            player.GetComponent<Player>().changeHP(hpMod);
        }
        if (player.GetComponent<Player>().getStat(0) > player.GetComponent<Player>().getMaxHP()) {
            player.GetComponent<Player>().resetHP();
        }
        sceneTransitions.songDone = true;
        return -1;
    }

    public override void musicLoader() {
        use(sceneTransitions.getPlayer(), sceneTransitions.getEnemy());
    }

    void Update()
    {
        if(sceneTransitions.activeHPotion && sceneTransitions.songDone2) {
            sceneTransitions.songDone2 = false;
            sceneTransitions.activeHPotion = false;
        }
    }
}
