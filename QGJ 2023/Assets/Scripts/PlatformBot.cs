using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBot : MonoBehaviour
{
    public GameObject player;
    public GameObject window;
    public GameObject repairBot;
    public GameObject flash;
    public float dist = 2.5f;
    bool isMoving = false;
    public GameObject[] smoke;
    public float dist2 = -6f;

    public float dir = 1;
    public GameObject child;

    public Sprite[] frames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist && player.GetComponent<InventoryTracker>().hasSmart) { //Close enough to object and has Smart Bot
            window.GetComponent<SpriteRenderer>().enabled = true; //Interaction window shown
            if (Input.GetKey ("e")) { //Press e
                window.SetActive(false);
                flash.GetComponent<SpriteRenderer>().enabled = true;
                StartCoroutine(moveToX(repairBot.transform, this.gameObject.transform.position, 2.0f)); //Fix PlatformBot
                this.enabled = false;
            }
        } else {
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

        float counter = 0;

        //Get the current position of the object to be moved
        Vector2 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x + (dir * 2.5f), startPos.y), counter / duration);
            yield return null;
        }

        flash.GetComponent<SpriteRenderer>().enabled = false;

        smoke[0].GetComponent<SpriteRenderer>().enabled = true;
        smoke[0].GetComponent<SpriteRenderer>().sprite = frames[0];
        yield return new WaitForSeconds(0.25f);
        smoke[0].GetComponent<SpriteRenderer>().sprite = frames[1];
        yield return new WaitForSeconds(0.25f);
        smoke[0].GetComponent<SpriteRenderer>().sprite = frames[2];
        yield return new WaitForSeconds(0.25f);
        smoke[0].GetComponent<SpriteRenderer>().sprite = frames[3];
        yield return new WaitForSeconds(0.25f);
        smoke[0].GetComponent<SpriteRenderer>().sprite = frames[0];
        smoke[0].GetComponent<SpriteRenderer>().enabled = false;

        isMoving = false;

        StartCoroutine(moveToX2(this.gameObject.transform, this.gameObject.transform.position, 2.0f)); //Move PlatformBot
    }

    IEnumerator moveToX2(Transform fromPosition, Vector3 toPosition, float duration) 
    {
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;

        float counter = 0;

        //Get the current position of the object to be moved
        Vector2 startPos = fromPosition.position;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x + dist2, startPos.y), counter / duration);
            yield return null;
        }

        isMoving = false;

        player.GetComponent<InventoryTracker>().hasPlatform = true;

        if (name == "Lifter Bot") {
            child.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
