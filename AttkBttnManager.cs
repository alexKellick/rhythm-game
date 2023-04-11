using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AttkBttnManager : MonoBehaviour//, IPointerEnterHandler
{
    /* ~~~~~ Main UI Buttons ~~~~~ */
    //public Button[] invntryBttns = new Button[4];
    //public GameObject sword1;

    /*public void OnPointerEnter(PointerEventData eventData) {
        Instantiate(sword1,
            SceneTransitions.inventoryButtons[0].transform.position,
            Quaternion.identity,
            SceneTransitions.inventoryButtons[0].transform
        );
        Debug.Log("on");
    }*/



    /* ~~~~~ Use Item Options ~~~~~ */

    //TODO: actually - just show all options! 4ish slots

    /*void Start()
    {
        foreach (Button b in invntryBttns) {
            b.onClick.AddListener(() => {Debug.Log(b);} );
        }
        //invntryBttns[0].AddListener
        
    }

    void Update()
    {
        
    }

    public void showButtons() {
        foreach (Button b in invntryBttns) {
            b.gameObject.SetActive(true);
        }
    }

    public void hideButtons() {
        foreach (Button b in invntryBttns) {
            b.gameObject.SetActive(false);
        }
    }*/
}
