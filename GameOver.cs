using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text gameOverText;
    void Start() {
        if (SceneTransitions.wonGame) {
            gameOverText.text = ("YOU WIN");
        } else {
            gameOverText.text = ("YOU LOSE");
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
