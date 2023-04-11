using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    public void Start()
    {
        updateStats();
    }

    // Update is called once per frame
    void Update()
    {
        /*float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Debug.Log(h);
        gameObject.transform.position = new Vector2 (transform.position.x + h, transform.position.y + v);
        //gameObject.transform.position = new */
        /*if (Input.GetKeyUp(KeyCode.A)) {
            gameObject.transform.position = new Vector2 (transform.position.x - hSpeed, transform.position.y);
        } else if (Input.GetKeyUp(KeyCode.D)) {
            gameObject.transform.position = new Vector2 (transform.position.x + hSpeed, transform.position.y);
        } else if (Input.GetKeyUp(KeyCode.W)) {
            gameObject.transform.position = new Vector2 (transform.position.x, transform.position.y + vSpeed);
        } else if (Input.GetKeyUp(KeyCode.S)) {
            gameObject.transform.position = new Vector2 (transform.position.x, transform.position.y - vSpeed);
        }*/
        //KeyCode keyUp = Input.anyKey();

    }

}
