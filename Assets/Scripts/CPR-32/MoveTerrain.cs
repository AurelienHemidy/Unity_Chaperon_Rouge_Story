using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTerrain : MonoBehaviour
{
    Animator ChaperonAnimator;
    float axisH, axisV;
    public GameObject Terrain;
    private Vector3 TerrainStart;
    private bool moveLeft;
    private bool moveRight;
    private bool isMove = false;

    public float duration = 1.5f;
    private void Awake() {
        ChaperonAnimator = GameObject.Find("pcr_walk").GetComponent<Animator>();
        TerrainStart = new Vector3(Terrain.transform.position.x, Terrain.transform.position.y, Terrain.transform.position.z);
    }
    void Start()
    {
        moveLeft = false;
        moveRight = false;
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
    public void OnPointerDownLeft()
    {
        moveLeft = true;
        ChaperonAnimator.SetBool("walk", true); 
        //StartGrayscaleRoutine();
    }
    public void OnPointerUpLeft()
    {
        moveLeft = false;
        ChaperonAnimator.SetBool("walk", false);
    }
    public void OnPointerDownRight()
    {
        //Reset();
        moveRight = true;
        ChaperonAnimator.SetBool("walk", true);
    }
    public void OnPointerUpRight()
    {
        moveRight = false;
        ChaperonAnimator.SetBool("walk", false);
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
            StartGrayscaleRoutine();
        }
        if(TerrainStart.x > Terrain.transform.position.x)
            Reset();

        if(moveLeft && isMove) {
            Terrain.transform.Translate(Vector3.right * 2 * Time.deltaTime);
        }
        if(moveRight) {
            Terrain.transform.Translate(-Vector3.right * 2 * Time.deltaTime);
        }
    }
}
