using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public SceneTransitions sceneTransitions;
    public TMP_Text gameOverText;
    void Start() {
        if (SceneTransitions.checkWonGame()) {
            gameOverText.text = ("YOU WIN");
        } else {
            gameOverText.text = ("YOU LOSE");
        }
    }
}
