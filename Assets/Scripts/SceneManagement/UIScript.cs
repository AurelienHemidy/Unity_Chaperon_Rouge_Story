using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public float transitionTimeLast = 8f;

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
  public void LoadLastLevel() {
        StartCoroutine(LoadLastLevel(LevelToLoad));
    }

  IEnumerator LoadLevel(int LevelIndex) {
      transition.SetTrigger("Start");

      yield return new WaitForSeconds(transitionTime);

      SceneManager.LoadScene(LevelIndex);
  }

  IEnumerator LoadLastLevel(int LevelIndex) {
      yield return new WaitForSeconds(9.5f);

      transition.SetTrigger("Start");

      yield return new WaitForSeconds(4.5f);

      SceneManager.LoadScene(LevelIndex);
  }

  public void PlayExperience() {
      LoadNextLevel();
  }

  public void NextScene() {
      LoadNextLevel();
  }
  public void LastScene() {
      LoadLastLevel();
  }

  public void Reload() {
      LevelToLoad = 0;
      LoadNextLevel();
  }
}
