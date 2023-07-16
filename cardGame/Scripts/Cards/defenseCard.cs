using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseCard : Card
{
    public int defense = 3;
    public bool isAttack = false;

    public override bool cardEffect(Character selectedCharacter) {
        if (selectedCharacter.GetComponent<PlayerCharacter>()) {
            selectedCharacter.addDefense(defense);
            return true;
        }
        else {
            return false;
        }
    }
}
