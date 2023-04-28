using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SongsManager : MonoBehaviour
{
    public SceneTransitions sceneTransitions;

    public float bpm;
    static float songPosition;
    //beats
    static float songPosInBeats;
    static float secPerBeat;
    static float dsptimesong;
    static float beatsShownInAdvance = 1;
    public static int notesFinished;
    static int score;
    GameObject note;
    float firstBeatOffset;
    int nextIndex = 0;
    static float[] notes = {/*.25f, .5f, .75f, 1f,
                     1.25f, 1.5f, 1.75f, 2f,*/
                     2.25f, 2.5f, 2.75f, 3f,
                     3.25f, 3.5f, 3.75f, 4f};

    void Awake() {
        notesFinished = 0;
        secPerBeat = 60f/bpm;
        dsptimesong = (float)AudioSettings.dspTime;
        GetComponent<AudioSource>().Play();
        sceneTransitions.currentScore = 0;
        transform.position = new Vector3(0f, 0f, 1f);
        sceneTransitions.setNotesFinished(0);
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float) (AudioSettings.dspTime - dsptimesong);
        songPosInBeats = songPosition/secPerBeat;

        if(nextIndex < notes.Length && notes[nextIndex] < (songPosInBeats + beatsShownInAdvance)) {
            note = Instantiate(Resources.Load("Note")) as GameObject;
            nextIndex++;
        }

        if (notesFinished == getNotesArray().Length) {
            notesFinished = 0;
            loadSceneWait();
            sceneTransitions.songDone = true;
            SceneManager.LoadScene("maingamescene");
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
    public static float getBeatsShownInAdvance() {
        return beatsShownInAdvance;
    }

    public static float[] getNotesArray() {
        return notes;
    }

    public static IEnumerator loadSceneWait() {
        yield return new WaitForSeconds(5);
    }
}
