using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoeDragDrop : dragDrop
{

    private GameObject playCardArea;

    new private void OnCollisionEnter2D(Collision2D collision) { //establishes drop zone as collision object
        if (collision.gameObject == playCardArea) {
            isOverDropZone = true;
            dropZone = collision.gameObject;
            Debug.Log("dropzone collision is playCardArea");
        }
    }
    new private void OnCollisionExit2D(Collision2D collision) { //removes drop zone as collision object
        isOverDropZone = false;
        Debug.Log("exited drop zone collision");
    }
    public override void endDrag() { //applies AOE card to all NPCs via selection Manager 
        isDragging = false;
        if (isOverDropZone && dropZone == playCardArea){ 
            selectionManager.applyAOE();
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
    public override void Awake() {
        playCardArea = GameObject.Find("playCardArea");
        canvas = GameObject.Find("playmatCanvas");
        selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        playerHandArea = GameObject.Find("playerHandArea");
    }
}
