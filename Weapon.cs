using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    // Start is called before the first frame update
    public int dmg;
    void Start()
    {

    }

    public override int use(GameObject player, GameObject enemy) {
        return dmg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}