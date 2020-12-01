using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartTimeline : MonoBehaviour
{

    public GameObject Timeline;
    Animator LoupAnimator;
    Animator ChaperonAnimator;
    public Canvas UICanvas;

    private void Awake() {
        LoupAnimator = GameObject.Find("grandmechantloup_6").GetComponent<Animator>();
        ChaperonAnimator = GameObject.Find("pcr_walk").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            UICanvas.GetComponent<MoveTerrain>().StopMove();
            UICanvas.GetComponent<MoveTerrain>().enabled = false;
            Timeline.GetComponent<PlayableDirector>().Play();
        }
    }


    public void EndTimeline() {
        UICanvas.GetComponent<MoveTerrain>().enabled = true;
        UICanvas.GetComponent<MoveTerrain>().CanMoveAgain();
    }

    public void StartLoupAnimationWalking() {
        LoupAnimator.SetBool("walk", true); 
    }
    public void StopLoupAnimationWalking() {
        LoupAnimator.SetBool("walk", false); 
    }

    public void StartChaperonAnimationWalking() {
        ChaperonAnimator.SetBool("walk", true); 
    }
    public void StopChaperonAnimationWalking() {
        ChaperonAnimator.SetBool("walk", false); 
    }

    public void StartLoupAnimationSitting() {
        LoupAnimator.SetBool("sit", true); 
    }
    public void StopLoupAnimationSitting() {
        LoupAnimator.SetBool("sit", false); 
    }
}
