using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Child class of dragDrop for cards that only target PC game objects. 
*/
public class pcDragDrop : dragDrop
{
    PlayerCharacter PC;
    public override void Awake() { //get refs including PC
        canvas = GameObject.Find("playmatCanvas");
        selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        playerHandArea = GameObject.Find("playerHandArea");
        PC = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
    }
//----------------------------------------------------
//Collision
    new private void OnCollisionEnter2D(Collision2D collision) { //only recognizes PC as a drop zone.
        dropZone = collision.gameObject;
        if(dropZone.GetComponent<PlayerCharacter>()) {
            isOverDropZone = true;
        }
    }
}
