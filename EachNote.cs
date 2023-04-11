using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Math;
//using static ClassGetter;
using static SongsManager;
using UnityEngine.SceneManagement;

//using Math;

public class EachNote : MonoBehaviour
{

    // Start is called before the first frame update
    Vector2 SpawnPos = new Vector3(-10f, 0f, -1f);
    Vector2 RemovePos = new Vector3(10f, 0f, -1f);
    float beatOfThisNote;
    float beatsShownInAdvance;
    float songPosInBeats;
    bool atEnd;
    Vector2 currentPos;
    //int notesFinished;
    //bool isFinished;
    //Vector2 clickPos = new Vector2(9f, 0f);
    float clickPos = 9f;
    void Start()
    {
        //notesFinished = 0;
        beatOfThisNote = SongsManager.getThisBeat();
        beatsShownInAdvance = SongsManager.getBeatsShownInAdvance();
        //Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        songPosInBeats = SongsManager.getSongPosInBeats();
        currentPos = transform.position;
        transform.position = Vector3.Lerp(
            SpawnPos,
            RemovePos,
            (beatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / beatsShownInAdvance);

        //notes do not despawn
        //TODO: fix
        if(currentPos.x == RemovePos.x) {
            if(!atEnd) {
                atEnd = true;
                SongsManager.notesFinished++;
                Debug.Log("here");
            }
        }

        if ((currentPos.x - clickPos <= 1) && (currentPos.x - clickPos >= 0) && Input.GetKeyDown(KeyCode.W) /*&& System.Math.Abs(beatOfThisNote - songPosInBeats) < .5*/) {
            //GetComponent<Renderer>().enabled = false;
            //Debug.Log(GetComponent<Renderer>().enabled);
            Destroy(this.gameObject);
            //Debug.Log(transform.position);
            //SceneTransitions.currentScore ++;
            //Debug.Log("POINT");
            //SongsManager.notesFinished++;
            //Debug.Log(SongsManager.getNotesArray().Length + " " + notesFinished);
            //SongsManager.addScore(1);
        }
        if (notesFinished == SongsManager.getNotesArray().Length) {
                StartCoroutine(SongsManager.loadSceneWait());
        }
        
        /*if (currentPos == RemovePos) {
            GetComponent<Renderer>().enabled = false;
        }*/

        /*if(songPosInBeats > beatOfThisNote + 2) {
            Destroy(this.gameObject);
        }*/
    }
}
