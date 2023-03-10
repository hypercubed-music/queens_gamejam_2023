using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairBot : MonoBehaviour
{
    public GameObject player;
    public GameObject window;
    public GameObject smartBot;
    public float dist = 2.5f;
    bool isMoving = false;
    public GameObject[] smoke;

    public Sprite[] frames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist && player.GetComponent<InventoryTracker>().hasRemote) { //Close enough to object and has remote
            window.GetComponent<SpriteRenderer>().enabled = true; //Interaction window shown
            if (Input.GetKey ("e")) { //Press e
                window.SetActive(false);
                StartCoroutine(moveToX(this.gameObject.transform, smartBot.transform.position, 1.0f)); //Fix SmartBot
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
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x - 1.0f, startPos.y), counter / duration);
            yield return null;
        }

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

        smartBot.GetComponent<SmartBot>().enabled = true;

        isMoving = false;
    }
}
