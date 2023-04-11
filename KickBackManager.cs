using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using EachNote;

public class KickBackManager : MonoBehaviour
{
    //seconds
    static float songPosition;
    //beats
    static float songPosInBeats;
    static float secPerBeat;
    static float dsptimesong;
    static float beatsShownInAdvance = 2;
    public GameObject Note;
    static int score;
    float firstBeatOffset;
    public TMP_Text showScore;
    public TMP_Text maxScore;
    //Vector2 notePos;

    float bpm;

    float[] notes = {17f, 17.75f, 18f, 18.75f, 19f, 19.5f, 20f, 20.75f};
    int nextIndex = 0;
    // Start is called before the first frame update
    void Start() {
        firstBeatOffset = 0;
        //firstBeatOffset = -.02f;
        bpm = 102;
        secPerBeat = 60f/bpm;
        //Debug.Log(secPerBeat);
        dsptimesong = (float)AudioSettings.dspTime;
        GetComponent<AudioSource>().Play();
        maxScore.text = ("Max Score = " + notes.Length.ToString());
        
    }

    /*public void playSong() {
        this.GetComponent<AudioSource>().Play();
    }*/

    public static float getBeatsShownInAdvance() {
        return beatsShownInAdvance;
    }


    // Update is called once per frame
    void Update() {
        songPosition = (float) (AudioSettings.dspTime - dsptimesong - firstBeatOffset);
        //Debug.Log(songPosition + " songposition");
        songPosInBeats = songPosition/secPerBeat;
        showScore.text = score.ToString();
        //notePose = 
        //Debug.Log(songPosInBeats + " songposinbeats");

        if (nextIndex < notes.Length && notes[nextIndex] < (songPosInBeats + beatsShownInAdvance)) {
            //Instantiate(Note);
            Note = Instantiate(Resources.Load("KickBackNote")) as GameObject;
            nextIndex++;

            //Debug.Log(nextIndex);
            //Debug.Log("here");
        }

       
    }

    public static int getScore() {
        return score;
    }

    public static void addScore(int addition) {
        score += addition;
    } 

    public static float getThisBeat() {
        return songPosInBeats + beatsShownInAdvance;
    }

    public static float getSongPosInBeats() {
        return songPosInBeats;
    }
}
