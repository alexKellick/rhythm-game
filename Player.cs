using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public void Start()
    {
        updateStats();
    }

    public override void updateStats(){
        base.updateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneTransitions.songDone2 || sceneTransitions.songDone || sceneTransitions.songDone3) {
            base.updateStats();
        }
    }

}
