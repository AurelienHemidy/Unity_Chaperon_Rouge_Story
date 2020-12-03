using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSound : MonoBehaviour
{
    public AudioSource ChampiSound;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            ChampiSound.Play();
        }
    }
}
