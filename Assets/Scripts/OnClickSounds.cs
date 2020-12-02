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
        CanvasDisappear();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, OreillesLoup)){
                OreillesLoupSound.Play();
                YeuxLoupSound.Stop();
                MainsLoupSound.Stop();
                BoucheLoupSound.Stop();
                NextSound(YeuxLoupObject, 6.5f);
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, YeuxLoup)){
                OreillesLoupSound.Stop();
                YeuxLoupSound.Play();
                MainsLoupSound.Stop();
                BoucheLoupSound.Stop();
                NextSound(MainsLoupObject, 7.5f);
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, MainsLoup)){
                OreillesLoupSound.Stop();
                YeuxLoupSound.Stop();
                MainsLoupSound.Play();
                BoucheLoupSound.Stop();
                NextSound(BoucheLoupObject, 5.5f);
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, BoucheLoup)){
                OreillesLoupSound.Stop();
                YeuxLoupSound.Stop();
                MainsLoupSound.Stop();
                BoucheLoupSound.Play();
                GameObject.Find("Main Camera").GetComponent<UIScript>().LastScene();
            }
        }
    }

     IEnumerator NextSoundCoro(GameObject objectSound, float time) {
        yield return new WaitForSeconds(time);
        objectSound.GetComponent<Animator>().enabled = true;
    }

    public void NextSound(GameObject objectSound, float time) {
        StartCoroutine(NextSoundCoro(objectSound, time));
    }

     IEnumerator CanvasDisappearCoro() {
        yield return new WaitForSeconds(18f);
        GameObject.Find("CanvasDisappearImage").GetComponent<Animator>().enabled = true;
    }

    public void CanvasDisappear() {
        StartCoroutine(CanvasDisappearCoro());
    }
}
