using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//basically everything inheriting from this class needs to override use and musicloader
public abstract class Item : MonoBehaviour {
    protected int amnt = 9;

    public virtual int use(GameObject player, GameObject enemy) {
        return 0;
    }

    public virtual void musicLoader() {
        SceneManager.LoadScene("MusicScene");
    }
}
