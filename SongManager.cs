using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using EachNote;

public class SongManager : MonoBehaviour
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
    float[] notes = {/*1f, 1.25f, 1.5f, 2f, 2.75f, 3.25f, 3.75f, 4.25f, 4.5f, 4.75f, */
                     5f, /*5.25f,*/ 5.5f, 6f, 6.75f, 7.25f, 7.75f, /*8.25f, 8.5f, 8.75f,*/
                     9f, 9.5f, 10f, 10.75f, 11.25f, 11.75f,
                     13f, 13.5f, 14f, 14.75f, 15.25f, 15.75f, 

                     17f, 17.25f, 17.5f, 18f, 18.75f, 19.25f, 19.75f, 20.25f, 20.5f, 20.75f,
                     21f, 21.25f, 21.5f, 22f, 22.75f, 23.25f, 23.75f, 24.25f, 24.5f, 24.75f,
                     25f, 25.25f, 25.5f, 26f, 26.75f, 27.25f, 27.75f, 28.25f, 28.5f, 28.75f,
                     29f, 29.25f, 29.5f, 30f, 30.75f, 31.25f, 31.75f, 32.25f, 32.5f, 32.75f,
                     
                     33f, 33.25f, 33.5f, 34f, 34.75f, 35.25f, 35.75f, 36.25f, 36.5f, 36.75f,
                     37f, 37.25f, 37.5f, 38f, 38.75f, 39.25f, 39.75f, 40.25f, 40.5f, 40.75f,
                     41f, 41.25f, 41.5f, 42f, 42.75f, 43.25f, 43.75f, 44.25f, 44.5f, 44.75f,
                     45f, 45.25f, 45.5f, 46f, 46.75f, 47.25f, 47.75f, 48.25f, 48.5f, 48.75f,
                     
                     
                     65f, 65.5f, 65.75f, 66.25f, 66.75f, 67.25f, 67.75f};
    //float[] notes = {5f};
    int nextIndex = 0;
    // Start is called before the first frame update
    void Start() {
        firstBeatOffset = .019f;
        //firstBeatOffset = -.02f;
        bpm = 120;
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
            Note = Instantiate(Resources.Load("Note")) as GameObject;
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
