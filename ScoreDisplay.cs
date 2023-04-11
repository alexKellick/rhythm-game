/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SongManager;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplay;
    //public int theScore;
    //public string theScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<UnityEngine.UI.Text>();
       //scoreDisplay.text = ("0");
    }

    // Update is called once per frame
    void Update()
    {

        scoreDisplay.text = SongManager.getScore().ToString();
        
    }
}*/