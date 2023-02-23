using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject player;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flip());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator flip() {
        //Make sure there is only one instance of this function running
        if (isMoving)
        {
            yield break; ///exit if this is still running
        }
        isMoving = true;

        while (!player.GetComponent<InventoryTracker>().hasFast) {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX; //Moving conveyor
            yield return new WaitForSeconds(0.25f);
        }

        this.enabled = false;
    }
}
