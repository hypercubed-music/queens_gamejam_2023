using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public GameObject[] nums;
    public GameObject[] slots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<BoxCollider2D>().enabled) {
            foreach(GameObject i in nums) {
                i.GetComponent<BoxCollider2D>().enabled = true;
            }

            foreach(GameObject i in slots) {
                i.GetComponent<SpriteRenderer>().enabled = true;
            }
        } else {
            foreach(GameObject i in nums) {
                i.GetComponent<BoxCollider2D>().enabled = false;
            }

            foreach(GameObject i in slots) {
                i.GetComponent<SpriteRenderer>().sprite = null;
                i.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
