using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
   public void QuitExperience() {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
  }

  public void PlayQuitExperience() {
      SceneManager.LoadScene("Scene 1 Introduction");
  }
}
