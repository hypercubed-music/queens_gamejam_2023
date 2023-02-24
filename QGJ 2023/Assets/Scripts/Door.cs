using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject player;
    public GameObject ceiling;
    public GameObject floor;
     public GameObject balloon;
    public GameObject window;
    public float dist = 2.5f;
    public GameObject keypad;
    public Sprite open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<InventoryTracker>().clues == 5 && player.GetComponent<PlayerMovement>().enabled) {
            if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist && player.transform.position.x < this.gameObject.transform.position.x) { //Close enough to object
                window.GetComponent<SpriteRenderer>().enabled = true; //Interaction window shown
                if (Input.GetKey ("e")) {
                    window.SetActive(false);
                    player.GetComponent<PlayerMovement>().enabled = false;
                    player.GetComponent<Rigidbody2D>().gravityScale = 0;
                    player.GetComponent<BoxCollider2D>().enabled = false;
                    balloon.GetComponent<Rigidbody2D>().gravityScale = 0;
                    ceiling.GetComponent<BoxCollider2D>().enabled = false;
                    floor.GetComponent<BoxCollider2D>().enabled = false;
                    keypad.GetComponent<SpriteRenderer>().enabled = true;
                    keypad.GetComponent<BoxCollider2D>().enabled = true;
                }
            } else {
                window.GetComponent<SpriteRenderer>().enabled = false; //Interaction window disappears
            }
        }

        if (player.GetComponent<InventoryTracker>().hasTall) {
            GetComponent<SpriteRenderer>().sprite = open;
            this.enabled = false;
        }
    }
}
