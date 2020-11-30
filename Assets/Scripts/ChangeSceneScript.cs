using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] int LevelToLoad;

    [SerializeField] bool autoIndex = true;

    private void Start() {
        if(autoIndex) {
        LevelToLoad = SceneManager.GetActiveScene().buildIndex+1;
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(LevelToLoad));
    }

    IEnumerator LoadLevel(int LevelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            if(SceneManager.GetActiveScene().buildIndex == 3) {
                if(GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isSelected) {
                    LoadNextLevel();
                }
            } else {
                LoadNextLevel();
            }
        }
    }
}
