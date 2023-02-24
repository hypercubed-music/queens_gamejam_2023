using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallBot : MonoBehaviour
{
    public GameObject segment1;
    public GameObject segment2;
    public GameObject balloon;
    public GameObject hold;
    public Sprite taller;
    public Sprite shorter;
    bool isMoving = false;
    public float dist = 1f;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().enabled && !activated) {
            segment1.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(moveToX(this.gameObject.transform, balloon.transform.position, 1.0f));
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
            toPosition = balloon.transform.position;
            counter += Time.deltaTime;
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x - dist, startPos.y), counter / duration);
            yield return null;
        }

        activated = true;
        yield return new WaitForSeconds(0.25f);
        segment1.GetComponent<SpriteRenderer>().sprite = taller;
        segment2.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        balloon.GetComponent<SpriteRenderer>().enabled = false;
        segment1.GetComponent<SpriteRenderer>().sprite = shorter;
        hold.GetComponent<SpriteRenderer>().enabled = true;
        segment2.GetComponent<SpriteRenderer>().enabled = false;

        isMoving = false;

        StartCoroutine(moveToX2(this.gameObject.transform, new Vector2(6.47f, 0), 1f));
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
            //toPosition = startPos;
            counter += Time.deltaTime;
            fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x, startPos.y), counter / duration);
            yield return null;
        }

        isMoving = false;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        segment1.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
        segment1.transform.position = new Vector2(segment1.transform.position.x, -1.35f);
        hold.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        hold.transform.position = new Vector2(segment1.transform.position.x - 0.45f, hold.transform.position.y);
        hold.GetComponent<BoxCollider2D>().enabled = true;
    }
}
