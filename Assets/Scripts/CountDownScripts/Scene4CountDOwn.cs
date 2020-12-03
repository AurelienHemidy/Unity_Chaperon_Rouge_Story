using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Scene4CountDOwn : MonoBehaviour
{
    [SerializeField] float startNumber = 100f;
    [SerializeField] float countSeconds = 10f;
    [SerializeField] float timer = 0f;
    [SerializeField] float timeMultiplier = 0f;

    private bool startCountDown = false;

    private Image Image;

    private void Awake() {
        Image = GetComponent<Image>();
    }

    void Start()
    {
        timeMultiplier = startNumber / countSeconds;
    }

    void Update()
    {
        if(startCountDown && timer <= countSeconds) {
        startNumber -= Time.deltaTime * timeMultiplier;
        Image.fillAmount = startNumber * .01f;
        timer += Time.deltaTime;
        } else {
            startCountDown = false;
            startNumber = 100f;
            timer = 0f;
            Image.fillAmount = 100;
        }
    }

    public void StartCount() {
        startCountDown = true;
    }

    public void StopCount() {
        TimelineFadeOut.Play();
        startCountDown = false;
    }
}
