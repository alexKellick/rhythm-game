using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnManager : MonoBehaviour
{
    System.Timers.Timer songTimer;
    bool isPlayerTurn;
    bool isEnemyTurn;
    bool newTurn;
    public GameObject player;
    public GameObject enemy;
    public Camera theCamera;
    //public GameObject newSword;
    public Button[] invntryBttns = new Button[4];
    public TMP_Text[] statDisplays = new TMP_Text[2];
    public RawImage[] statBackgrounds = new RawImage[2];
    GameObject activeItem;
    bool buttonPressed;
    //public Button attackButton;
    //public Button itemButton;
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < enemy.GetComponent<Enemy>().inventory.Length; i++) {
            int newIndex = i;
            if (enemy.GetComponent<Enemy>().inventory[i] != null) {
                Instantiate(enemy.GetComponent<Enemy>().inventory[newIndex],
                invntryBttns[newIndex].transform.position,
                Quaternion.identity,
                invntryBttns[newIndex].transform);
            }
        }
        //TODO: rewrite with variables
        for (int i = 0; i < player.GetComponent<Player>().inventory.Length; i++) {
            int newIndex = i;

            if(player.GetComponent<Player>().inventory[i] != null) {
                //invntryBttns[i].onClick.AddListener(() => Debug.Log(player.GetComponent<Player>().inventory[newIndex]));
                Instantiate(
                    player.GetComponent<Player>().inventory[newIndex],
                    invntryBttns[newIndex].transform.position,
                    Quaternion.identity, 
                    invntryBttns[newIndex].transform
                );
               
                invntryBttns[i].onClick.AddListener(() => activeItem = player.GetComponent<Player>().inventory[newIndex]);
                invntryBttns[i].onClick.AddListener(() => buttonPressed = true);

            }
        }
        isPlayerTurn = true; 
        SceneTransitions.inventoryButtons = invntryBttns;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerTurn) {
            if(buttonPressed) {
                //Debug.Log("b" /*+ activeItem.GetComponent<Item>().amnt*/);
                //activeItem = null;
                buttonPressed = false;
                SceneManager.LoadScene("MusicScene", LoadSceneMode.Additive);

                disableUIMain();
                playersInvisible();

                Scene currentscene = SceneManager.GetSceneByName("MusicScene");
                StartCoroutine(setActiveScene(currentscene));
                
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("MusicScene"));
                //Debug.Log(SceneManager.GetActiveScene().name);
                //switchTurn();
                //activeItem.GetComponent<Item>().use(player, enemy);

            }

            activeItem.GetComponent<Item>().use(player, enemy);
        } else if(isEnemyTurn) {
            enemy.GetComponent<Enemy>().inventory[0].GetComponent<Item>().use(enemy, player);
            switchTurn();
        }

        
        

        //for testing purposes
        if (Input.GetKeyUp(KeyCode.E)) {
            newTurn = false;
            switchTurn();
        }

        if(SceneTransitions.songDone) {
            SceneTransitions.songDone = false;
            SceneTransitions.songDone2 = true;
            enableUIMain();
            playersVisible();
        }
        
        if(newTurn) {
            newTurn = false;
            switchTurn();
        }
    }

    

    void playerTurn() {
        buttonPressed = false;
        foreach(Button b in invntryBttns) {
            b.gameObject.SetActive(true);
        }
        if(buttonPressed) {
            activeItem.GetComponent<Item>().use(player, enemy);
        }

        //TODO: :( make scenes work ):
        //SceneManager.LoadScene("SampleScene");
        //await Task.Delay(5000);
        //waitForGame();
        //songTimer = new System.Timers.Timer(4000);
        //songTimer.Enabled = true;
        //Thread.Sleep(5000);
        //songTimer.Elapsed += loadFightScene;
        //songTimer.AutoReset = true;

        //enemy.GetComponent<Enemy>().changeHP(-2);

    }

    /*void runTimer() {
        songTimer = new System.Timers.Timer(4000);
        songTimer.Elapsed += SceneManager.LoadScene("maingamescene");
    }*/

    void loadFightScene(object source, ElapsedEventArgs e) {
        SceneManager.LoadScene("maingamescene");
        //Debug.Log("here");
    }

    void checkEndGame() {
        if(enemy.GetComponent<Enemy>().getStat(0)<=0) {
            SceneTransitions.wonGame = true;
            SceneManager.LoadScene("EndScene");
        }
        if(player.GetComponent<Player>().getStat(0)<=0) {
            SceneTransitions.wonGame = false;
            SceneManager.LoadScene("EndScene");
        }
    }

    void disableUIMain() {
        foreach(Button b in invntryBttns) {
            b.gameObject.SetActive(false);
        }
        foreach(TMP_Text t in statDisplays) {
            t.enabled = false;
        }
        foreach(RawImage r in statBackgrounds) {
            r.gameObject.SetActive(false);
        }
    }

    //what actually switches to the enemy's turn. At the moment, it should *only* be done from here.
    void enableUIMain() {
        switchTurn();
        foreach(Button b in invntryBttns) {
            b.gameObject.SetActive(true);
        }
        foreach(TMP_Text t in statDisplays) {
            t.enabled = true;
        }
        foreach(RawImage r in statBackgrounds) {
            r.gameObject.SetActive(true);
        }
    }

    void playersInvisible() {
        player.GetComponent<Renderer>().enabled = false;
        enemy.GetComponent<Renderer>().enabled = false;
    }

    void playersVisible() {
        player.GetComponent<Renderer>().enabled = true;
        enemy.GetComponent<Renderer>().enabled = true;
    }

    void enemyTurn() {
        foreach(Button b in invntryBttns) {
            b.gameObject.SetActive(false);
        }
    }
    
    ///<summary>
    ///switches between character turns, including changing background color and switching turn booleans.
    ///</summary>
    void switchTurn() {
        checkEndGame();
        isPlayerTurn = !isPlayerTurn;
        isEnemyTurn = !isEnemyTurn;
        if (isPlayerTurn) {
            theCamera.backgroundColor = Color.blue;
            playerTurn();

        } else {
            theCamera.backgroundColor = Color.red;
            enemyTurn();
        }

    }

    public IEnumerator setActiveScene(Scene scene) {
        int i = 0;
        while(i == 0) {
            i++;
            yield return null;
        }
        SceneManager.SetActiveScene(scene);
        yield break;
    }


    /* ~~~ Getters ~~~ */

    ///<summary>
    ///Returns whether or not it is currently the player's turn.
    ///</summary>
    ///<returns>A boolean representing the current state of the player's turn.
    ///</returns>
    public bool getPlayerTurn() {
        return isPlayerTurn;
    }

    public bool getEnemyTurn() {
        return isEnemyTurn;
    }

    public GameObject getEnemy() {
        return enemy;
    }

    public GameObject getPlayer() {
        return player;
    }

}
