using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public float dist = 10f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > (5 * dist)) {
            transform.position = new Vector3(6 * dist, 0, -10); //Move camera right thrice
        } else if (player.transform.position.x > (3 * dist)) {
            transform.position = new Vector3(4 * dist, 0, -10); //Move camera right twice
        } else if (player.transform.position.x < (-3 * dist)) {
            transform.position = new Vector3(-4 * dist, 0, -10); //Move camera left twice
        } else if (player.transform.position.x < -dist) {
            transform.position = new Vector3(-2 * dist, 0, -10); //Move camera left
        } else if (player.transform.position.x > dist) {
            transform.position = new Vector3(2 * dist, 0, -10); //Move camera right
        } else {
            transform.position = new Vector3(0, 0, -10); //Default camera position
        }
    }
}
