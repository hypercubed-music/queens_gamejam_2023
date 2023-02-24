using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(end());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator end() {
        yield return new WaitForSeconds(duration);
        Application.Quit();
    }
}
