using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Child class of dragDrop for cards that only target single NPC game object.
*/
public class npcDragDrop : dragDrop
{
    new private void OnCollisionEnter2D(Collision2D collision) { //only recognizes NPCs as drop zones.
        dropZone = collision.gameObject;
        if(dropZone.GetComponent<NPC>()) {
            isOverDropZone = true;
        }
    }
}
