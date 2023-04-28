using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    //hp, hit, str, def, av (spd)
    public int[] stats = new int[5];
    TMP_Text showStats;
    public bool isPlayerCharacter;
    int maxHP;

    public GameObject[] inventory = new GameObject[4];
    public SceneTransitions sceneTransitions;

    void Start(){}

    void Awake() {
        if(isPlayerCharacter) {
            //stats = sceneTransitions.getPlayerStats();
            showStats = sceneTransitions.getPlayerText();
        } else {
            //stats = sceneTransitions.getEnemyStats();
            showStats = sceneTransitions.getEnemyText();
        }
        this.maxHP = stats[0];
    }

    public void changeHP(int hp) {
        //Debug.Log("original = " + stats[0]);
        stats[0] += hp;
        //Debug.Log("changed = " + stats[0]);
        //Debug.Log("hp = " + hp);
        if (stats[0] < 0) {
            stats[0] = 0;
        }
        if (stats[0] > maxHP) {
            stats[0] = maxHP;
        }
        //Debug.Log("change hp ");
        //Debug.Log("end = " + stats[0]);
        updateStats();
    }

    public bool checkIfPlayer() {
        return isPlayerCharacter;
    }

    public int getMaxHP() {
        return maxHP;
    }

    public int getStat(int index) {
        return stats[index];
    }

    /// <summary>
    /// Allows for temporary changing of individual stats.
    /// hp, hit, str, def, sp.
    /// </summary>
    ///<param name="index">The index of the value to change.</param>
    ///<param name="statValue">The new value of the stat.</param>
    public void setStat(int index, int statValue) {
        //Debug.Log("Here");
        stats[index] = statValue;
        if (stats[index] < 0) {
            stats[index] = 0;
        }
        if (stats [0] > maxHP) {
            stats[0] = maxHP;
        }
        updateStats();
    }

    public void resetHP() {
        stats[0] = maxHP;
    }

    public int[] getAllStats() {
        return stats;
    }

    public void setAllStats(int[] newStats) {
        stats = newStats;
    }

    ///<summary>
    ///Redisplays all stats for the character calling it. Typically only used in Character.
    ///</summary>
    public virtual void updateStats() {
        if(isPlayerCharacter) {
            showStats = sceneTransitions.getPlayerText();
            showStats.text = ("HP = " + stats[0] +
                            "\nHIT = " + stats[1] +
                            "\nSTR = " + stats[2] +
                            "\nDEF = " + stats[3] +
                            "\nSPD = " + stats[4]);            
        } else {
            showStats = sceneTransitions.getEnemyText();
            showStats.text = ("HP = " + stats[0] +
                            "\nHIT = " + stats[1] +
                            "\nSTR = " + stats[2] +
                            "\nDEF = " + stats[3] +
                            "\nSPD = " + stats[4]);   
        }

    }
}
