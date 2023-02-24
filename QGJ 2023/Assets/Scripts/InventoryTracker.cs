using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTracker : MonoBehaviour
{
    public bool hasRemote = false;
    public bool hasSmart = false;
    public bool hasPlatform = false;

    public bool hasFast = false;
    bool[] track = {false};
    public Sprite[] newSprite;
    public int clues = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasRemote && !track[0]) {
            GetComponent<SpriteRenderer>().sprite = newSprite[1]; //Change sprite
            GetComponent<Animator>().SetBool("hasRemote", true); //Change walking animation
            track[0] = true;
        }
    }
}
