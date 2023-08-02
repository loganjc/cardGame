using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Child class of dragDrop for cards that target all NPC game objects.
*/
public class aoeDragDrop : dragDrop
{
    private GameObject playCardArea;

    public override void Awake() { //Finds the play card area to be recognized as drop zone.
        playCardArea = GameObject.Find("playCardArea");
        canvas = GameObject.Find("playmatCanvas");
        selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        playerHandArea = GameObject.Find("playerHandArea");
    }
//----------------------------------------------------
//Collision
    new private void OnCollisionEnter2D(Collision2D collision) { //establishes drop zone as collision object
        dropZone = collision.gameObject;
        Debug.Log("dropzone collision is " + dropZone);
        if (collision.gameObject == playCardArea) {
            isOverDropZone = true;
        }
    }
    public override void endDrag() { //applies AOE card to all NPCs via applyAOE() selection Manager method. 
        isDragging = false;
        if (isOverDropZone){ 
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
}
