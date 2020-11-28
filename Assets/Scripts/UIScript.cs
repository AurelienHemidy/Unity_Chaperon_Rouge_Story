using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
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

  public void PlayExperience() {
      SceneManager.LoadScene("Scene 1 Introduction");
  }

  public void NextScene() {
      SceneManager.LoadScene(LevelToLoad);
  }
}
