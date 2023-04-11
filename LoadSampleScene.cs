using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadSampleScene : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        //SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnButtonPress() {
        SceneManager.LoadScene("SampleScene");
    }
}
