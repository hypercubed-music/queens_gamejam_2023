using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator flash() {
        while (true) {
            transform.localScale = new Vector3(0.1f, 0.1f, 1);
            yield return new WaitForSeconds(0.25f);
            transform.localScale = new Vector3(0.05f, 0.05f, 1);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
