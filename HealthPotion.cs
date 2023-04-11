using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Potion
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        //amnt = originalAmnt;
        //amnt = 6;
        //Debug.Log("a" + amnt);
    }

    void OnEnable() {
        //base.amnt = 5;
        //Debug.Log(amnt);
    }

 
    public override int use(GameObject player, GameObject enemy) {
        //Debug.Log("c" + amnt);
        //Debug.Log("here" + amnt);
        //return base.use(player, enemy);
        int hpMod = base.use(player, enemy);
        //Debug.Log(hpMod + " mod");
        //amnt = 10;
        if (amnt > 0) {
            player.GetComponent<Player>().changeHP(hpMod);
            //Debug.Log("change hp");
        }
        if (player.GetComponent<Player>().getStat(0) > player.GetComponent<Player>().getMaxHP()) {
            player.GetComponent<Player>().resetHP();
        }
        return -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
