using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementToDragScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private bool onHover = false;
   public void OnDrag(PointerEventData eventData) {

        Plane plane = new Plane(Vector3.forward, transform.position);
        Ray ray = eventData.pressEventCamera.ScreenPointToRay(eventData.position);
        float distance;
        if (plane.Raycast(ray, out distance) && !GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isSelected)
        {
            transform.position = ray.origin + ray.direction * distance;
            
        }
   } 
   public void OnEndDrag(PointerEventData eventData) {
        if(onHover && !GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isSelected) {
            GetComponentInChildren<Animator>().enabled = true;
            GameObject.Find("Main Camera").GetComponent<DragAndDrop>().isSelected = true;
        }
   }
    private void OnTriggerEnter(Collider other) {
        onHover = true;
    }
    private void OnTriggerExit(Collider other) {
        onHover = false;
    }
}
