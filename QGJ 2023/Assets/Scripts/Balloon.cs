using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    public GameObject player;
    public GameObject window;
    public float dist = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist) { //Close enough to object
            window.GetComponent<SpriteRenderer>().enabled = true; //Interaction window shown
            if (Input.GetKey ("e")) { //Press e
                SceneManager.LoadScene(2);
            }
        } else {
            window.GetComponent<SpriteRenderer>().enabled = false; //Interaction window disappears
        }
    }
}
