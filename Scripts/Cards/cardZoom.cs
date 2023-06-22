using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardZoom : MonoBehaviour
{
    public GameObject canvas;
    private GameObject zoomCard;

    public void Awake() {
        canvas = GameObject.Find("playmatCanvas");
    }

    public void onHoverEnter() {
        zoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity); //could just instantiate the image component of card?
        zoomCard.transform.SetParent(canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("zoom"); //changes layer to "zoom"
        
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 344); //scale up the instantiated card
    }

    public void onHoverExit() {
        Destroy(zoomCard);
    }  
}
