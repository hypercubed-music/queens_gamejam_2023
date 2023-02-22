using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float height = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        if (Input.GetKey ("d") || Input.GetKey(KeyCode.RightArrow)) {
            GetComponent<SpriteRenderer>().flipX = false;
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey ("a") || Input.GetKey(KeyCode.LeftArrow)) {
            GetComponent<SpriteRenderer>().flipX = true;
            pos.x -= speed * Time.deltaTime;
        }
 
        transform.position = pos;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "Floor" && (Input.GetKey ("space") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w")))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, height), ForceMode2D.Impulse);
        }
    }
}
