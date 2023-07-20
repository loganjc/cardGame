using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public TurnManager TM;
    public SelectionManager SM;
    public List<Card> cards; //populate this with the NPC cards
    PlayerCharacter PC;

//-------------------------------------------------------
    //Selection Manager Messager
    public void OnMouseDown() { //select card
        Debug.Log("clicked on " + name);
        if (selectionManager.getHasCard() == true) {
            selectionManager.useCard(this);
            Debug.Log("used a card on " + name);
        }
    }

//----------------------------------------------------------
    //Damage + Death Methods

    public override void death(){
        Debug.Log("Death");
        this.gameObject.SetActive(false);
        TM.removeNPC(this);
        Destroy(this);
            Debug.Log(this + " has been destroyed");
    }


//--------------------------------------------------------
    //Turn taking methods
    public void takeTurn() {
        this.resetDefense();
        this.attackPC();
    }


//--------------------------------------------------------
    //Attack methods === FIXME: might replace these later with cards! Mostly for prototyping NPC turns
    public void attackPC() {
        PC.takeDamage(1);
        Debug.Log(this + " has attacked player for 1 damage!");
    }


    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.Find("turnManager").GetComponent<TurnManager>();
        TM.addNPC(this);
        SM = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
        SM.addNPC(this);
        PC = GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacter>();
        hpBar.setMaxHp(HP);
    }
}
