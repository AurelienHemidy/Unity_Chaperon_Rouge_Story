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
    public GameObject OreillesLoupObjectContainer;
    public GameObject YeuxLoupObjectContainer;
    public GameObject MainsLoupObjectContainer;
    public GameObject BoucheLoupObjectContainer;

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
                NextSound(YeuxLoupObject, OreillesLoupObjectContainer, 5f);
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, YeuxLoup)){
                OreillesLoupSound.Stop();
                YeuxLoupSound.Play();
                MainsLoupSound.Stop();
                BoucheLoupSound.Stop();
                NextSound(MainsLoupObject, YeuxLoupObjectContainer, 6f);
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, MainsLoup)){
                OreillesLoupSound.Stop();
                YeuxLoupSound.Stop();
                MainsLoupSound.Play();
                BoucheLoupSound.Stop();
                NextSound(BoucheLoupObject, MainsLoupObjectContainer, 4f);
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, BoucheLoup)){
                OreillesLoupSound.Stop();
                YeuxLoupSound.Stop();
                MainsLoupSound.Stop();
                BoucheLoupSound.Play();
                BoucheLoupObjectContainer.GetComponent<Animator>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<UIScript>().LastScene();
            }
        }
    }

     IEnumerator NextSoundCoro(GameObject objectSound, GameObject ObjectOnClick, float time) {
        yield return new WaitForSeconds(time);
        objectSound.GetComponent<Animator>().enabled = true;
        ObjectOnClick.GetComponent<Animator>().enabled = true;
    }

    public void NextSound(GameObject objectSound, GameObject ObjectOnClick, float time) {
        StartCoroutine(NextSoundCoro(objectSound, ObjectOnClick, time));
    }

     IEnumerator CanvasDisappearCoro() {
        yield return new WaitForSeconds(19f);
        GameObject.Find("CanvasDisappearImage").GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(10f);
        OreillesLoupObject.GetComponent<Animator>().enabled = true;
    }

    public void CanvasDisappear() {
        StartCoroutine(CanvasDisappearCoro());
    }
}
