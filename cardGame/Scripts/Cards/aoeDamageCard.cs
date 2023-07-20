using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Base class for cards that do damage to all enemies.
*/
public class aoeDamageCard : Card
{
    public int damage = 2;

    public override bool cardEffect(Character selectedCharacter){
        if (selectedCharacter.GetComponent<NPC>()) {
            selectedCharacter.takeDamage(damage);
            return true;
        }
        else {
            return false;
        }
    }
}
