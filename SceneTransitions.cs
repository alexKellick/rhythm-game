using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// a class to get/set variables that need to transition between scenes and/or any others used batween classes
/// </summary>

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneTransitions", order = 1)]

public class SceneTransitions : ScriptableObject {
    public Button startGameButton;
    public Button[] inventoryButtons;
    public int currentScore;
    // Start is called before the first frame update
    GameObject playerHolder;
    GameObject enemyHolder;
    public static bool wonGame;
    public bool songDone;
    public bool songDone2;
    public bool songDone3;
    public int[] playerStatsHold;
    public int[] enemyStatsHold;
    public int[] strMusMod;
    public int[] tempPlayerStats;
    public int[] tempEnemyStats;
    public static bool notFirstTurn;
    public int notesFinished;

    public TMP_Text[] statDisplays;


    public bool activeSword;
    public bool activeHPotion;
    void Start() {
        startGameButton.onClick.AddListener(() => SceneManager.LoadScene("maingamescene"));
    }

    void Awake() {
        notFirstTurn = false;
        activeSword = false;
        activeHPotion = false;
        wonGame = false;
    }



    public void holdPlayer(GameObject heldPlayer) {
        playerHolder = heldPlayer;
        playerStatsHold = heldPlayer.GetComponent<Player>().getAllStats();
    }

    public int[] getPlayerStats() {
        return playerHolder.GetComponent<Player>().getAllStats();
    }

    public int[] getEnemyStats() {
        return enemyHolder.GetComponent<Enemy>().getAllStats();
    }

    public GameObject getPlayer() {
        return playerHolder;
    }

    public void holdEnemy(GameObject heldEnemy) {
        enemyHolder = heldEnemy;
        enemyStatsHold = heldEnemy.GetComponent<Enemy>().getAllStats();
    }

    public GameObject getEnemy() {
        return enemyHolder;
    }

    public TMP_Text getPlayerText() {
        return statDisplays[1];
    }

    public TMP_Text getEnemyText() {
        return statDisplays[0];
    }

    public void setStatText(TMP_Text[] statsYeah){
        statDisplays = statsYeah;
    }

    public TMP_Text[] getStatTexts() {
        return statDisplays;
    }

    public static bool isNotFirstTurn() {
        return notFirstTurn;
    }

    public void setNotFirstTurn(bool turn) {
        notFirstTurn = turn;
    }

    public void setWonGame(bool won) {
        wonGame = won;
    }

    public static bool checkWonGame() {
        return wonGame;
    }

    public int getNotesFinished() {
        return notesFinished;
    }

    public void addNotes(int points) {
        notesFinished += points;
    }

    public void setNotesFinished(int setNotes) {
        notesFinished = setNotes;
    }
}
