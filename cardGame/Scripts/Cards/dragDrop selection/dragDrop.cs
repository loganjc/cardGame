using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour //this script goes on card objs to allow drag and drop behavior
{
    public GameObject canvas;
    public GameObject playerHandArea;
    public SelectionManager selectionManager;
    public bool isDragging = false;
    public bool isOverDropZone = false;
    public GameObject dropZone;
    public GameObject startParent;
    public Vector2 startPosition;
    public GameObject card;
    
    public virtual void Awake() { //get refs
        canvas = GameObject.Find("playmatCanvas");
        selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        playerHandArea = GameObject.Find("playerHandArea");
    }

    // Update is called once per frame
    public void Update() //updates card.position to match mouse.position when dragging cards
    {
        if(isDragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //moves card to mouse position
            transform.SetParent(canvas.transform, true);
            card = this.gameObject;
            selectionManager.cardSelect(card);
        }
    }
//----------------------------------------------------
//Collision
    public void OnCollisionEnter2D(Collision2D collision) { //establishes drop zone as collision object
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    public void OnCollisionExit2D(Collision2D collision) { //removes drop zone as collision object
        isOverDropZone = false;
    }

    public void startDrag() {
        startPosition = transform.position;
        // startParent = transform.parent.gameObject;
        isDragging = true;
    }

    public virtual void endDrag() { //applies card to NPC/ PC via selection Manager
        isDragging = false;
        if (isOverDropZone && dropZone.GetComponent<Character>() != null){ 
            selectionManager.useCard(dropZone.GetComponent<Character>());
            Debug.Log("Played card " +  card);
            if (card.activeSelf) { //in case useCard() fails for some reason, reset card position
                transform.position = startPosition;
                transform.SetParent(playerHandArea.transform, false);
                Debug.Log("Did not play card " + card);
            }
        }
        else { //otherwise it goes back to where it was when we started dragging
            transform.position = startPosition;
            transform.SetParent(playerHandArea.transform, false);
            Debug.Log("Did not play card " + card);
        }
    }
}
