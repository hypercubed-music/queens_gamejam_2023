using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformClue : MonoBehaviour
{
    public GameObject player;
    public GameObject window;
    public GameObject cam;
    public GameObject board;
    public Sprite key;
    public float dist = 3f;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        if (name == "Clue (4)") {
            GetComponent<Animator>().enabled = false;
            StartCoroutine(moveToX(this.gameObject.transform, cam.transform.position, 1.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist && name != "Clue (4)") { //Close enough to object
            window.GetComponent<SpriteRenderer>().enabled = true; //Interaction window shown
            if (Input.GetKey ("e") && name != "Clue (4)") { //Press e
                window.SetActive(false); //Interaction window disappears
                GetComponent<Animator>().enabled = false;
                StartCoroutine(moveToX(this.gameObject.transform, cam.transform.position, 1.0f));
            }
        } else if (name != "Clue (4)") {
            window.GetComponent<SpriteRenderer>().enabled = false; //Interaction window disappears
        }
    }

    IEnumerator moveToX(Transform fromPosition, Vector3 toPosition, float duration)
    {
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;
        cam.GetComponent<MoveCam>().enabled = false;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector2 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x, toPosition.y), counter / duration);
            yield return null;
        }

        GetComponent<SpriteRenderer>().sprite = key;
        this.gameObject.transform.localScale = new Vector3(3, 3, 3);
        GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Key");
        board.GetComponent<SpriteRenderer>().sprite = key;
        yield return new WaitForSeconds(1.5f);

        isMoving = false;
        cam.GetComponent<MoveCam>().enabled = true;
        this.gameObject.SetActive(false);

    }
}
