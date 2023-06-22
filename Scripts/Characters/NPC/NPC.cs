using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{

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
    new public void takeDamage(int damage) {
        damage = damage - defense;
        defense = defense - damage;
        if (defense < 0) {
            defense = 0;
        }
        if ( damage > 0) {
            HP = HP - damage;
        }
        hpBar.setHp(HP);
        if (HP <= 0){
            death();
        }
    }

    public void death(){
        this.gameObject.SetActive(false);
        Destroy(this);
            Debug.Log("NPC has been destroyed");
    }
//--------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        hpBar.setMaxHp(HP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
