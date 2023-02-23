using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBot : MonoBehaviour
{
    public GameObject player;
    float speed;
    bool isMoving = false;
    public float dist = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveToX(this.gameObject.transform, player.transform.position, 1.0f)); //Move to player
        speed = player.GetComponent<PlayerMovement>().speed;
        player.GetComponent<InventoryTracker>().hasSmart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && player.transform.position.x > -38) { //Flawed follow player script
            Vector3 pos = transform.position;
        
            if (Input.GetKey ("d") || Input.GetKey(KeyCode.RightArrow)) {
                transform.position = new Vector2(player.transform.position.x - dist, transform.position.y);
                GetComponent<SpriteRenderer>().flipX = false;
                pos.x = player.transform.position.x - dist;
            }
            if (Input.GetKey ("a") || Input.GetKey(KeyCode.LeftArrow)) {
                transform.position = new Vector2(player.transform.position.x + dist, transform.position.y);
                GetComponent<SpriteRenderer>().flipX = true;
                pos.x = player.transform.position.x + dist;
            }
 
            transform.position = pos;
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
            toPosition = player.transform.position;
            counter += Time.deltaTime;
            if (player.GetComponent<SpriteRenderer>().flipX) {
                fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x + dist, startPos.y), counter / duration);
            } else {
                fromPosition.position = Vector2.Lerp(startPos, new Vector2(toPosition.x - dist, startPos.y), counter / duration);
            }
            yield return null;
        }

        isMoving = false;
    }
}
