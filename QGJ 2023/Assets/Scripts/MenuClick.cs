using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour
{
    public Camera cam;
    public GameObject player;
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
                if (hit.collider.name == "Play Button") {
                    player.GetComponent<Animator>().SetBool("hasRemote", false);
                    SceneManager.LoadScene(1);
                } else if (hit.collider.name == "Quit Button") {
                    Application.Quit();;
                }
            }
        }
    }
}
