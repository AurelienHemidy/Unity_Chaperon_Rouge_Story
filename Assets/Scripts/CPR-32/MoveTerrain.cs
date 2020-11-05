using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTerrain : MonoBehaviour
{
   public GameObject Terrain;
   private bool moveLeft;
   private bool moveRight;
    void Start()
    {
        //Terrain = GameObject.Find("Plane");
        moveLeft = false;
        moveRight = false;
    }
    public void OnPointerDownLeft()
    {
        moveLeft = true;
    }
    public void OnPointerUpLeft()
    {
        moveLeft = false;
    }
    public void OnPointerDownRight()
    {
        moveRight = true;
    }
    public void OnPointerUpRight()
    {
        moveRight = false;
    }

    private void Update() {
        if(moveLeft) {
            //Terrain.transform.Translate(-Vector3.right * 1 * Time.deltaTime);
            Debug.Log("Mouvement vers la gauche");
        }
        if(moveRight) {
            //Terrain.transform.Translate(Vector3.right * 1 * Time.deltaTime);
             Debug.Log("Mouvement vers la droite");
        }
    }
}
