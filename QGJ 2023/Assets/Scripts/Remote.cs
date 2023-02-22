using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public GameObject player;
    public GameObject window;
    public float dist = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist) {
            window.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKey ("e")) {
                player.GetComponent<InventoryTracker>().hasRemote = true;
                this.gameObject.SetActive(false);
            }
        } else {
            window.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
