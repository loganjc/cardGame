using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is the Player Character Class. It stores player stats, status effects, etc.
    Other methods will need call the methods in this class to interact with PC.
*/
public class PlayerCharacter : Character
{
    



    public override void death(){
        Debug.Log("Death");
        this.gameObject.SetActive(false);
        Destroy(this);
            Debug.Log(this + " has been destroyed");
    }

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
