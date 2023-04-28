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
    float clickPos = 9f;
    public SceneTransitions sceneTransitions;
    
    void Start() {
        beatOfThisNote = SongsManager.getThisBeat();
        beatsShownInAdvance = SongsManager.getBeatsShownInAdvance();
    }

    // Update is called once per frame
    void Update() {
        songPosInBeats = SongsManager.getSongPosInBeats();
        currentPos = transform.position;
        transform.position = Vector3.Lerp(
            SpawnPos,
            RemovePos,
            (beatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / beatsShownInAdvance);

        if(RemovePos.x - currentPos.x <= 1) {
            if(!atEnd) {
                atEnd = true;
                SongsManager.notesFinished++;
            }
        }

        if ((currentPos.x - clickPos <= 1) && (currentPos.x - clickPos >= 0) && Input.GetKeyDown(KeyCode.W) && System.Math.Abs(beatOfThisNote - songPosInBeats) < .1) {
            sceneTransitions.addNotes(1);
            Destroy(this.gameObject);
        }
    }
}
