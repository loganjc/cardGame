using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : Card
{
    public int damage = 1;
    public bool isAttack = true;

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
