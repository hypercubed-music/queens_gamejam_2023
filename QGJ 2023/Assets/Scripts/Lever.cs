using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<InventoryTracker>().hasFast) {
            GetComponent<SpriteRenderer>().flipX = true;
            this.enabled = false;
        }
    }
}
