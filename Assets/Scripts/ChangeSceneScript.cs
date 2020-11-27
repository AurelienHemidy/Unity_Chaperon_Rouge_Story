using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    [SerializeField] int LevelToLoad;

    [SerializeField] bool autoIndex = true;

    private void Start() {
        if(autoIndex) {
        LevelToLoad = SceneManager.GetActiveScene().buildIndex+1;
        }
        Debug.Log("ça commence");
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            SceneManager.LoadScene("Scene 3 Entree de foret");
            Debug.Log("ça touche");
        }
        Debug.Log("COLLISION");
    }
}
