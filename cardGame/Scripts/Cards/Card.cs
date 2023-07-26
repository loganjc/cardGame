using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour
{
    public SelectionManager selectionManager;
    public PlayerCharacter PC;
    public bool isSelected = false;
    public int shuffleNumber;
    public int cost = 1; //FIXME: something is fucking up with the cost comparison in SelectionManager

    public int getCost() {
        return this.cost;
    }

    public void OnMouseDown(){
        isSelected = true;
        selectionManager.cardSelect(this.gameObject);
        //Debug.Log("Clicked on " + this);
    }

//-----------------------------------------------------------------
//Card effects methods
    public void useCard(Character selectedCharacter) {
        if (selectedCharacter.GetComponent<NPC>() != null) { //apply NPC effet
            this.cardEffect(selectedCharacter.GetComponent<NPC>());
            if (!PC) {
                getPC();
            }
            PC.removeEnergy(this.cost);
        }
        else if (selectedCharacter.GetComponent<PlayerCharacter>()) {
            this.cardEffect(selectedCharacter.GetComponent<PlayerCharacter>());
            if (!PC) {
                getPC();
            }
            PC.removeEnergy(this.cost);
        }
        else {
            Debug.Log("Invalid target");
        }
    }

    public virtual bool cardEffect(Character selectedCharacter){
        return false;
    }

//------------------------------------------------------------------
//Setup methods
    public void getPC() { //used in useCard() to find PC GO
        if (!PC) {
            GameObject PC_GO = GameObject.Find("PlayerCharacter");
            PC = PC_GO.GetComponent<PlayerCharacter>(); 
        }
    }

    public void Start() {
        getPC();
    }
}
