﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CountdownSound : MonoBehaviour
{
    public float startNumber = 100f;        // The number that we countDown
    public float countSeconds = 10f;        // Time needed for counting
    public float timer = 0f;
    private float timeMultiplier = 0f;

    PlayableDirector TimelineFadeOut;

    private bool startCountDown = false;

    private Image Image;

    private void Awake() {
        Image = GetComponent<Image>();
        TimelineFadeOut = GameObject.Find("TimeLineFadeOut").GetComponent<PlayableDirector>();
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
        // if(startNumber < 0) {
        //     StopCount();
        // }
    }

    public void StartCount() {
        // StartCoroutine(StartCountDown());
        startCountDown = true;
    }

    public void StopCount() {
        TimelineFadeOut.Play();
    }

    // public void StopCount() {
    //     StartCoroutine(StopCountDown());
    // }
}
