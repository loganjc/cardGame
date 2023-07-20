using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseCard : Card
{
    public int defense = 3;

    public override bool cardEffect(Character selectedCharacter) { //FIXME: not working for some reason. Problem might be in selection manager
        if (selectedCharacter.GetComponent<PlayerCharacter>()) {
            selectedCharacter.addDefense(defense);
            Debug.Log(defense + " added to " + selectedCharacter);
            return true;
        }
        else {
            return false;
        }
    }
}
