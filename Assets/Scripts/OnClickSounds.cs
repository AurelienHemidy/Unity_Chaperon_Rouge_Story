using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickSounds : MonoBehaviour
{
    public LayerMask OreillesLoup;
    public LayerMask YeuxLoup;
    public LayerMask MainsLoup;
    public LayerMask BoucheLoup;

    public GameObject OreillesLoupObject;
    public GameObject YeuxLoupObject;
    public GameObject MainsLoupObject;
    public GameObject BoucheLoupObject;

    public AudioSource OreillesLoupSound;
    public AudioSource YeuxLoupSound;
    public AudioSource MainsLoupSound;
    public AudioSource BoucheLoupSound;

    private Camera _cam;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, OreillesLoup)){
                
                Debug.Log("oreilles !");
                OreillesLoupSound.Play();
                YeuxLoupSound.Stop();
                MainsLoupSound.Stop();
                BoucheLoupSound.Stop();
                //Fire le son des oreilles
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, YeuxLoup)){
                Debug.Log("yeux !");
                OreillesLoupSound.Stop();
                YeuxLoupSound.Play();
                MainsLoupSound.Stop();
                BoucheLoupSound.Stop();
                //Fire le son des yeux
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, MainsLoup)){
                Debug.Log("mains !");
                OreillesLoupSound.Stop();
                YeuxLoupSound.Stop();
                MainsLoupSound.Play();
                BoucheLoupSound.Stop();
                //Fire le son des mains
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, BoucheLoup)){
                Debug.Log("mains !");
                OreillesLoupSound.Stop();
                YeuxLoupSound.Stop();
                MainsLoupSound.Stop();
                BoucheLoupSound.Play();
                //Fire le son des mains
            }
        }
    }
}
