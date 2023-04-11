using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    // Start is called before the first frame update
    //public int amnt;
    public int effectValue;
    public int originalAmnt;
    
    //does not run
    void Start()
    {
        //amnt = originalAmnt;
        //Debug.Log("start");
    }

    void Awake() {
        //amnt = originalAmnt;
        //amnt = 2;
        //Debug.Log("awake");
        //Debug.Log(amnt);
        amnt = 6;
    }

    /*void OnEnable() {
        amnt = originalAmnt;
        Debug.Log("enamble");
    }*/

    public override int use(GameObject player, GameObject enemy) {
        //Debug.Log("d" + amnt);
        //Debug.Log("use" + amnt);
        if(amnt > 0){
            amnt -= 1;
            return effectValue;
        } else {
            Debug.Log("Out of uses! " + amnt);
            return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
