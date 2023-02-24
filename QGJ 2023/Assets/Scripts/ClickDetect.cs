using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class ClickDetect : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
    public GameObject balloon;
    public GameObject window;
    public GameObject ceiling;
    public GameObject floor;
    public Sprite red;
    bool isNum = false;
    int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            Vector2 ray = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit) {
                if (hit.collider.name == name) {
                    window.SetActive(true);
                    ceiling.GetComponent<BoxCollider2D>().enabled = true;
                    floor.GetComponent<BoxCollider2D>().enabled = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                    player.GetComponent<PlayerMovement>().enabled = true;
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<Rigidbody2D>().gravityScale = 1;
                    balloon.GetComponent<Rigidbody2D>().gravityScale = -1;
                } else {
                    foreach (int i in Enumerable.Range(0, GetComponent<Keypad>().nums.Length)) {
                        if (hit.collider.name == GetComponent<Keypad>().nums[i].name) {
                            isNum = true;
                            index = i;
                            break;
                        }
                    }

                    if (isNum) {
                        if (index <= 9) {
                            foreach (GameObject i in GetComponent<Keypad>().slots) {
                                if (i.GetComponent<SpriteRenderer>().sprite == null) {
                                    i.GetComponent<SpriteRenderer>().sprite = GetComponent<Keypad>().nums[index].GetComponent<SpriteRenderer>().sprite;
                                    break;
                                }
                            }
                        } else if (index == 10) {
                            foreach (GameObject i in GetComponent<Keypad>().slots) {
                                i.GetComponent<SpriteRenderer>().sprite = null;
                            }
                        } else {
                            bool a = GetComponent<Keypad>().slots[0].GetComponent<SpriteRenderer>().sprite == GetComponent<Keypad>().nums[5].GetComponent<SpriteRenderer>().sprite;
                            bool b = GetComponent<Keypad>().slots[1].GetComponent<SpriteRenderer>().sprite == GetComponent<Keypad>().nums[4].GetComponent<SpriteRenderer>().sprite;
                            bool c = GetComponent<Keypad>().slots[2].GetComponent<SpriteRenderer>().sprite == GetComponent<Keypad>().nums[1].GetComponent<SpriteRenderer>().sprite;
                            bool d = GetComponent<Keypad>().slots[3].GetComponent<SpriteRenderer>().sprite == GetComponent<Keypad>().nums[6].GetComponent<SpriteRenderer>().sprite;
                            bool e = GetComponent<Keypad>().slots[4].GetComponent<SpriteRenderer>().sprite == GetComponent<Keypad>().nums[6].GetComponent<SpriteRenderer>().sprite;
                            
                            if (a && b && c && d && e) {
                                player.GetComponent<InventoryTracker>().hasTall = true;
                                ceiling.GetComponent<BoxCollider2D>().enabled = true;
                                floor.GetComponent<BoxCollider2D>().enabled = true;
                                GetComponent<SpriteRenderer>().enabled = false;
                                GetComponent<BoxCollider2D>().enabled = false;
                                player.GetComponent<PlayerMovement>().enabled = true;
                                player.GetComponent<BoxCollider2D>().enabled = true;
                                player.GetComponent<Rigidbody2D>().gravityScale = 1;
                                balloon.GetComponent<Rigidbody2D>().gravityScale = -1;
                                gameObject.SetActive(false);
                            } else {
                                StartCoroutine(Wrong());
                            }
                        }
                    }
                    isNum = false;
                }
            }
        }
    }

    IEnumerator Wrong() 
    {
        for (int j = 1; j <= 5; j++) {
            foreach (GameObject i in GetComponent<Keypad>().slots) {
                i.GetComponent<SpriteRenderer>().sprite = red;
            }
            yield return new WaitForSeconds(0.1f);
            foreach (GameObject i in GetComponent<Keypad>().slots) {
                i.GetComponent<SpriteRenderer>().sprite = null;
            }
        }
    }
}
