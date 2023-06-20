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
        Debug.Log("Clicked on " + this);
    }

    public void useCard(NPC selectedNPC) {
        this.cardEffect(selectedNPC);
        getPC();
        PC.removeEnergy(this.cost);
    }

    public void cardEffect(NPC selectedNPC){
        selectedNPC.takeDamage(1);
        //card effects
    }

    public void getPC() {
        if (!PC) {
            GameObject PC_GO = GameObject.Find("PlayerCharacter");
            PC = PC_GO.GetComponent<PlayerCharacter>(); 
        }
    }

    public void Start() {
        if (!PC) {
            GameObject PC_GO = GameObject.Find("PlayerCharacter");
            PC = PC_GO.GetComponent<PlayerCharacter>(); 
        }
    }
}
