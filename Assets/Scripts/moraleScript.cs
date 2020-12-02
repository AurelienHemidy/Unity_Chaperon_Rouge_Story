using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moraleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        moraleNextScene();
    }
     IEnumerator StartCountDown() {
        yield return new WaitForSeconds(31);
        GetComponent<UIScript>().LoadNextLevel();
    }

    public void moraleNextScene() {
        StartCoroutine(StartCountDown());
    }
}
