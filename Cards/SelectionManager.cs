using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static bool hasCard = false;
    private static Card selectedCard;
    private NPC selectedNPC;
    [SerializeField] CardPile discard;
    [SerializeField] static PlayerHand playerHand;
    


    public void OnMouseDown() {
        Debug.Log("You clicked on " + name);
    }
    public static void cardSelect(Card playerCard) { //
        selectedCard = playerCard;
        hasCard = true;
        Debug.Log("Selection manager card select");
    }
    public static void useCard(NPC target) { //applies card to NPC, sends card from hand --> discard pile
        selectedCard.cardEffect(target);
        PlayerHand.toDiscard(selectedCard);
        selectedCard = null;
        hasCard = false;
    }
}
