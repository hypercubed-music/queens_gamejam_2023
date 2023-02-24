using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMovement : MonoBehaviour
{
    public float speed = 2f;
    bool track = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        if (transform.position.x < 13 && !track) {
            GetComponent<SpriteRenderer>().flipX = false;
            pos.x += speed * Time.deltaTime;
            if (transform.position.x >= 12.9f) {
                track = true;
            }
        } else if (transform.position.x > -13.5f && track) {
            GetComponent<SpriteRenderer>().flipX = true;
            pos.x -= speed * Time.deltaTime;
            if (transform.position.x <= -13.4f) {
                track = false;
            }
        }
 
        transform.position = pos;
    }
}
