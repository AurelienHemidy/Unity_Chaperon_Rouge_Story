using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GaletteBeurreDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    Vector2 startPosition = new Vector2(-101.7245f, 0f);

    [SerializeField] public bool onBasket = false;

    [SerializeField] private Canvas canvas;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

   public void OnPointerDown(PointerEventData eventData) {
       //Debug.Log("OnPointerDown");
   }
   public void OnBeginDrag(PointerEventData eventData) {
      //Debug.Log("OnBeginDrag");
   }
   public void OnEndDrag(PointerEventData eventData) {
        if(onBasket) {
           GetComponent<Image>().enabled = false;
           GameObject.Find("GaletteBouteille").GetComponent<GaletteBouteilleDragDrop>().isChoose = true;
       } else {
           rectTransform.anchoredPosition = startPosition;
       }
   }
   public void OnDrag(PointerEventData eventData) {
       Vector2 currentMousePosition = eventData.position;
       Debug.Log(eventData.delta);
       if(!GameObject.Find("GaletteBouteille").GetComponent<GaletteBouteilleDragDrop>().isChoose) {
            rectTransform.anchoredPosition += (eventData.delta / canvas.scaleFactor);
       } 
   }
    private void OnTriggerEnter(Collider other) {
         if(other.tag == "Player") {
            onBasket = true;
         }
    }
    private void OnTriggerExit(Collider other) {
         if(other.tag == "Player" ) {
            onBasket = false;
         }
    }
}

