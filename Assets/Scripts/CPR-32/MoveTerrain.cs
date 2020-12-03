using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTerrain : MonoBehaviour
{
    Animator ChaperonAnimator;
    public GameObject Terrain;
    private Vector3 TerrainStart;
    private bool moveLeft;
    private bool moveRight;
    private bool isMove = false;

    private bool canMove = true;

    public float duration = 1.5f;
    private void Awake() {
        ChaperonAnimator = GameObject.Find("pcr_walk").GetComponent<Animator>();
        TerrainStart = new Vector3(Terrain.transform.position.x, Terrain.transform.position.y, Terrain.transform.position.z);
        ResetBothBtn();
        //StartGrayscaleRoutine();
    }
    void Start()
    {
        moveLeft = false;
        moveRight = false;
        AnimationBeginningLaunch();
    }

    public void StartGrayscaleRoutine() {
        StartCoroutine(GrayscaleRoutine(duration, true));
    }

    public void Reset() {
        StartCoroutine(GrayscaleRoutine(duration, false));
    }
    private IEnumerator GrayscaleRoutine(float duration, bool isGrayscale) {
        float time = 0;
        while(duration >= time) {
            float ratio = time / duration;
            float grayAmount = isGrayscale ? ratio : 1 - ratio;
            SetGrayscale(grayAmount);
            time += Time.deltaTime;
            yield return null;
        }
        SetGrayscale(isGrayscale ? 1 : 0);
    }

    public void SetGrayscale(float amount = 1) {
        GameObject.Find("BtnBackward").GetComponent<Image>().material.SetFloat("_GrayscaleAmount", amount);
    }

    //
    public void StartGrayscaleRoutineBothBtn() {
        StartCoroutine(GrayscaleRoutineBothBtn(duration, true));
    }

    public void ResetBothBtn() {
        StartCoroutine(GrayscaleRoutineBothBtn(duration, false));
    }

    private IEnumerator GrayscaleRoutineBothBtn(float duration, bool isGrayscale) {
        float time = 0;
        while(duration >= time) {
            float ratio = time / duration;
            float grayAmount = isGrayscale ? ratio : 1 - ratio;
            SetGrayscaleBothBtn(grayAmount);
            time += Time.deltaTime;
            yield return null;
        }
        SetGrayscaleBothBtn(isGrayscale ? 1 : 0);
    }

    public void SetGrayscaleBothBtn(float amount = 1) {
        GameObject.Find("BtnBackward").GetComponent<Image>().material.SetFloat("_GrayscaleAmount", amount);
        GameObject.Find("BtnForward").GetComponent<Image>().material.SetFloat("_GrayscaleAmount", amount);
    }

    IEnumerator AnimationBeginning() {
        yield return new WaitForSeconds(1);
        GameObject.Find("BtnBackward").GetComponent<Animator>().enabled = true;
        GameObject.Find("BtnForward").GetComponent<Animator>().enabled = true;
    }

    public void AnimationBeginningLaunch() {
        StartCoroutine(AnimationBeginning());
    }


    public void OnPointerDownLeft()
    {
        moveLeft = true;
        if(canMove)
            ChaperonAnimator.SetBool("walk", true); 
    }
    public void OnPointerUpLeft()
    {
        moveLeft = false;
        ChaperonAnimator.SetBool("walk", false);
    }
    public void OnPointerDownRight()
    {
        moveRight = true;
        if(canMove)
            ChaperonAnimator.SetBool("walk", true);
    }
    public void OnPointerUpRight()
    {
        moveRight = false;
        ChaperonAnimator.SetBool("walk", false);
    }

    public void StopMove() {
        ChaperonAnimator.SetBool("walk", false);
        canMove = false;
    }

    public void CanMoveAgain() {
        canMove = true;
    }

    private void Update() {
        if(TerrainStart.x >= Terrain.transform.position.x) {
            isMove = true;
            if(moveRight) {
                ChaperonAnimator.SetBool("walk", true);
            }  
        } else {
            isMove = false;
            ChaperonAnimator.SetBool("walk", false);
            //StartGrayscaleRoutine();
        }
        if(TerrainStart.x > Terrain.transform.position.x)
            //Reset();

        if(moveLeft && isMove) {
            Terrain.transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
        if(moveRight) {
            Terrain.transform.Translate(-Vector3.right * 3 * Time.deltaTime);
        }
    }
}
