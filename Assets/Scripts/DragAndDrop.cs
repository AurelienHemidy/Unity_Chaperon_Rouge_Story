using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
{
    public LayerMask BeurreVin;
    public LayerMask GaletteVin;
    public GameObject BeurreVinObject;
    public GameObject GaletteVinObject;
    Vector3 point = new Vector3();
    bool isUpon = false;

    private Camera _cam;

    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    private void OnGUI() {
        Event   currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = _cam.pixelHeight - currentEvent.mousePosition.y;

        point = _cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1.35f));
    }

    public void OnDrag(PointerEventData eventData) {
       if(isUpon) {
            BeurreVinObject.transform.position = point;
       } 
   }


    void Update()
    {
        //Debug.Log(point);
        if(Input.GetButtonDown("Fire1")){
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, BeurreVin)){
                Debug.Log("BeurreVin");
                isUpon = true;
                //Debug.Log(Input.mousePosition);
                //Debug.Log(BeurreVinObject.GetComponent<RectTransform>().anchoredPosition);
                
            }
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, GaletteVin)){
                Debug.Log("GaletteVin");
                //Debug.Log(Input.mousePosition);
                //GaletteVinObject.GetComponent<RectTransform>().anchoredPosition += point;
            }
        }
        if(Input.GetButtonUp("Fire1")) {
            isUpon = false;
        }
    }
}