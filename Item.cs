using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Start is called before the first frame update
    protected int amnt = 9;
    void Start()
    {
        
    }


    public virtual int use(GameObject player, GameObject enemy) {
        //Debug.Log("item");
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
