using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    // Start is called before the first frame update
    void Start()
    {

    }

    public override int use(GameObject player, GameObject enemy) {
        //dont use, try threads?
        //TurnManager.getEnemy().GetComponent<Enemy>().changeHP(-2);
        //while(!SceneTransitions.songDone) {}
        SceneTransitions.songDone2 = false;
        int strMod = player.GetComponent<Character>().getStat(2);
        int defMod = enemy.GetComponent<Character>().getStat(3);
        int totalDmg = -2 - strMod + defMod; 
        if (totalDmg < 0) {
            enemy.GetComponent<Character>().changeHP(totalDmg);
        }
        //Debug.Log(totalDmg);
        //enemy.GetComponent<Enemy>().changeHP(-2 - strMod + defMod);
        Debug.Log("here");
        return 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
