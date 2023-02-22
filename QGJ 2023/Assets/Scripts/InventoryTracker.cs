using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTracker : MonoBehaviour
{
    public bool hasRemote = false;
    bool[] track = {false};
    public Sprite[] newSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasRemote && !track[0]) {
            GetComponent<SpriteRenderer>().sprite = newSprite[0]; //Change sprite
        }
    }
}
