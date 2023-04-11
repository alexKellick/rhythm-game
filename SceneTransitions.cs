using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// a class to get/set variables that need to transition between scenes and/or any others used batween classes
/// </summary>


public class SceneTransitions : MonoBehaviour {
    public Button startGameButton;
    public static Button[] inventoryButtons;
    public static int currentScore;
    // Start is called before the first frame update
    public static GameObject playerHolder;
    public static GameObject enemyHolder;
    public static bool wonGame;
    public static bool songDone;
    public static bool songDone2;
    void Start()
    {
        startGameButton.onClick.AddListener(() => SceneManager.LoadScene("maingamescene"));

    }



    public void holdPlayer(GameObject heldPlayer) {
        playerHolder = heldPlayer;
    }

    public void holdEnemy(GameObject heldEnemy) {
        enemyHolder = heldEnemy;
    }

    public void emptyPlayer() {
        playerHolder = null;
    }

    public void emptyEnemy() {
        enemyHolder = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
