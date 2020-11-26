using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator ChaperonAnimator;
    float axisH, axisV;
    bool moveLeft, moveRight = false;

    [SerializeField] float walkSpeed = 2f;
    private void Awake() {
        ChaperonAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");
        if(axisV > 0) {
            //transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
            ChaperonAnimator.SetBool("walk", true);
        } else {
            ChaperonAnimator.SetBool("walk", false);
        }
    }
}
