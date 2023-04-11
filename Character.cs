using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update

    //hp, hit, str, def, av (spd)
    public int[] stats = new int[5];
    protected float hSpeed = 2.47f;
    protected float vSpeed = 2.38f;
    public TMP_Text showStats;
    int maxHP;

    public GameObject[] inventory = new GameObject[4];

    void Start()
    {
        //maxHP = stats[0];
        
    }

    void Awake() {
        maxHP = stats[0];
    }

    public void changeHP(int hp) {
        stats[0] += hp;
        if (stats[0] < 0) {
            stats[0] = 0;
        }
        updateStats();
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
        stats[index] = statValue;
        if (stats[index] < 0) {
            stats[index] = 0;
        }
        updateStats();
    }

    public void resetHP() {
        stats[0] = maxHP;
    }

    ///<summary>
    ///Redisplays all stats for the character calling it. Typically only used in Character.
    ///</summary>
    protected void updateStats() {
        showStats.text = ("HP = " + stats[0] +
                            "\nHIT = " + stats[1] +
                            "\nSTR = " + stats[2] +
                            "\nDEF = " + stats[3] +
                            "\nSPD = " + stats[4]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
