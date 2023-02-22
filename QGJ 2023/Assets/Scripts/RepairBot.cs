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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.gameObject.transform.position.x - player.transform.position.x) < dist && player.GetComponent<InventoryTracker>().hasRemote) {
            window.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKey ("e")) {
                window.SetActive(false);
                StartCoroutine(moveToX(this.gameObject.transform, smartBot.transform.position, 1.0f));
                this.enabled = false;
            }
        } else {
            window.GetComponent<SpriteRenderer>().enabled = false;
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
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x, startPos.y), counter / duration);
            yield return null;
        }

        smoke[0].GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        smoke[0].transform.rotation = new Quaternion(0, 0, 180, 0);
        yield return new WaitForSeconds(0.25f);
        smoke[0].transform.rotation = new Quaternion(0, 0, 0, 0);
        yield return new WaitForSeconds(0.25f);
        smoke[0].transform.rotation = new Quaternion(0, 0, 180, 0);
        yield return new WaitForSeconds(0.25f);
        smoke[0].transform.rotation = new Quaternion(0, 0, 0, 0);
        smoke[0].GetComponent<SpriteRenderer>().enabled = false;

        isMoving = false;
    }
}
