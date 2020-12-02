using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementToDragMushroom : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private bool onHover = false;
    Animator[] animators;
    int mushroomsFound = 0;
   public void OnDrag(PointerEventData eventData) {

        Plane plane = new Plane(Vector3.forward, transform.position);
        Ray ray = eventData.pressEventCamera.ScreenPointToRay(eventData.position);
        float distance;
        if (plane.Raycast(ray, out distance) && !GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isFoundMushroom)
        {
            transform.position = ray.origin + ray.direction * distance;
            
        }
   } 
   public void OnEndDrag(PointerEventData eventData) {
        if(onHover && !GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isFoundMushroom) {
            animators = GetComponentsInChildren<Animator>();
            foreach (Animator animator in animators)
            {
                animator.enabled = true;
            }
            mushroomsFound++;
            if(mushroomsFound == 7)
                GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isFoundMushroom = true;
        }
   }
    private void OnTriggerEnter(Collider other) {
        onHover = true;
    }
    private void OnTriggerExit(Collider other) {
        onHover = false;
    }
}
