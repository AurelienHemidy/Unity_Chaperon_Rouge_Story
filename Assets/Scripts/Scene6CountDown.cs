using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Scene6CountDown : MonoBehaviour
{
    [SerializeField] float startNumber = 100f;        // The number that we countDown
    [SerializeField] float countSeconds = 10f;        // Time needed for counting
    [SerializeField] float timer = 0f;
    [SerializeField] float timeMultiplier = 0f;

    [SerializeField] PlayableDirector TimelineFadeOut;

    private bool startCountDown = false;

    private Image Image;

    private void Awake() {
        Image = GetComponent<Image>();
    }

    void Start()
    {
        timeMultiplier = startNumber / countSeconds;    // Get the number that we want to count / the seconds that we want to count it
    }

    void Update()
    {
        if(startCountDown && timer <= countSeconds) {
        startNumber -= Time.deltaTime * timeMultiplier;    // Count
        Image.fillAmount = startNumber * .01f;
        timer += Time.deltaTime;    // Just to show the time passed from the begining
        } else {
            startCountDown = false;
            startNumber = 100f;
            timer = 0f;
            Image.fillAmount = 100;
            //TimelineFadeOut.Play();
        }
    }

    public void StartCount() {
        // StartCoroutine(StartCountDown());
        startCountDown = true;
    }

    public void StopCount() {
        TimelineFadeOut.Play();
        startCountDown = false;
    }

    // public void StopCount() {
    //     StartCoroutine(StopCountDown());
    // }
}
