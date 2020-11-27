using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTerrain : MonoBehaviour
{
    Animator ChaperonAnimator;
    float axisH, axisV;
    public GameObject Terrain;
    private bool moveLeft;
    private bool moveRight;
    private void Awake() {
        ChaperonAnimator = GameObject.Find("pcr_walk").GetComponent<Animator>();
    }
    void Start()
    {
        //Terrain = GameObject.Find("Plane");
        moveLeft = false;
        moveRight = false;
    }
    public void OnPointerDownLeft()
    {
        moveLeft = true;
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
        ChaperonAnimator.SetBool("walk", true);
    }
    public void OnPointerUpRight()
    {
        moveRight = false;
        ChaperonAnimator.SetBool("walk", false);
    }

    private void Update() {
        if(moveLeft) {
            Terrain.transform.Translate(Vector3.right * 2 * Time.deltaTime);
        }
        if(moveRight) {
            Terrain.transform.Translate(-Vector3.right * 2 * Time.deltaTime);
        }
    }
}
