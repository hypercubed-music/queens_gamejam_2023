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
        if (player.transform.position.x < -dist) {
            transform.position = new Vector3(-2 * dist, 0, -10); //Move camera left
        } else if (player.transform.position.x > dist) {
            transform.position = new Vector3(2 * dist, 0, -10); //Move camera right
        } else {
            transform.position = new Vector3(0, 0, -10); //Default camera position
        }
    }
}