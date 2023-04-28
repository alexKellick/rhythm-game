using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public Button startGameButton;
    // Start is called before the first frame update
    void Start() {
        startGameButton.onClick.AddListener(() => SceneManager.LoadScene("maingamescene"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
