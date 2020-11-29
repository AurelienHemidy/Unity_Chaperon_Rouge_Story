using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

   [SerializeField] int LevelToLoad;
   private void Start() {
     LevelToLoad = SceneManager.GetActiveScene().buildIndex+1;
   }
   public void QuitExperience() {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
  }

  public void LoadNextLevel() {
        StartCoroutine(LoadLevel(LevelToLoad));
    }

    IEnumerator LoadLevel(int LevelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(LevelIndex);
    }

  public void PlayExperience() {
      LoadNextLevel();
  }

  public void NextScene() {
      LoadNextLevel();
  }
}
