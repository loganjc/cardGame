using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
DragDrop is very important!!!
---------------------------------------------
This is the parent class for all other dragDrop classes: aoeDragDrop, npcDragDrop, & pcDragDrop
Child classes override the OnCollisionEnter() & endDrag() methods to limit drop zone to specific GameObject types and
to call the appropriate SelectionManager card application method.
*/
public class dragDrop : MonoBehaviour
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
    
//----------------------------------------------------
//Setup Methods - get GO references for class to work. 
    public virtual void Awake() { //get refs, overridden in some child classes.
        canvas = GameObject.Find("playmatCanvas");
        selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        playerHandArea = GameObject.Find("playerHandArea");
    }

//----------------------------------------------------
//Update - Actually causes the card to move onscreen with the mouse position.
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
//Collision Methods - tells class when it has an object to apply a card to.
    public void OnCollisionEnter2D(Collision2D collision) { //establishes drop zone as collision object
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    public void OnCollisionExit2D(Collision2D collision) { //removes drop zone as collision object
        isOverDropZone = false;
    }
//----------------------------------------------------
//Start & Stop Methods - begin and end card drag process.
    public void startDrag() {
        startPosition = transform.position;
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
