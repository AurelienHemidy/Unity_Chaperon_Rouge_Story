using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCPR : MonoBehaviour
{
    public void StartWalking() {
        GetComponent<Animator>().SetBool("walk", true);
    }
    public void StopWalking() {
        GetComponent<Animator>().SetBool("walk", false);
    }
}
