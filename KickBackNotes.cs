using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Math;
//using static ClassGetter;
using static KickBackManager;
//using Math;

public class KickBackNotes : MonoBehaviour
{
    //public float beatsShownInAdvance = 3f;
    //public float songPosInBeats = 1f;
    //float beatOfThisNote = SongManager.getThisBeat();
    //public GameObject Note;
    // Start is called before the first frame update
    Vector2 SpawnPos = new Vector2(-10f, 0f);
    Vector2 RemovePos = new Vector2(10f, 0f);
    float beatOfThisNote;
    float beatsShownInAdvance;
    float songPosInBeats;
    Vector2 currentPos;
    //Vector2 clickPos = new Vector2(9f, 0f);
    float clickPos = 9f;
    void Start()
    {
        beatOfThisNote = KickBackManager.getThisBeat();
        beatsShownInAdvance = KickBackManager.getBeatsShownInAdvance();
    }

    // Update is called once per frame
    void Update()
    {
        //notes are all moving together
        //TODO: fix this aaaa?

        songPosInBeats = KickBackManager.getSongPosInBeats();
        //Debug.Log(songPosInBeats);
        currentPos = transform.position;
        //Debug.Log(currentPos);
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (beatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / beatsShownInAdvance
        );
        //Debug.Log(transform.position);

        if ((currentPos.x - clickPos <= 1) && (currentPos.x - clickPos >= 0) && Input.GetKeyDown(KeyCode.W) && System.Math.Abs(beatOfThisNote - songPosInBeats) < .5) {
            //Debug.Log(currentPos.x + " current " + clickPos + " click " + (currentPos.x-clickPos));
            Destroy(this.gameObject);
            KickBackManager.addScore(1);
            //Debug.Log(SongManager.getScore());

        }

        
        if (currentPos == RemovePos) {
            GetComponent<Renderer>().enabled = false;
        }

        if(songPosInBeats > beatOfThisNote + 2) {
            Destroy(this.gameObject);
        }
    }
}
