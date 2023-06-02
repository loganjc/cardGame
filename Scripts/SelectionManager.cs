using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static bool hasCard = false;
    public GameObject selectedCard;
    private Card selectedCardCardClass; 
    private NPC selectedNPC;
    public GameObject discard;
    public PlayerHand playerHand;

    public void debugDiscard() {
        if (discard) {
            Debug.Log("Discard attribute = " + discard);
        }
        else {
            Debug.Log("Discard attribute is null for some reason :(");
        }
    }

    public bool getHasCard() {
        return hasCard;
    }
    public void cardSelect(GameObject playerCard) { //
        selectedCard = playerCard;
        hasCard = true;
        Debug.Log("Selection manager: " + playerCard + " selected.");
        Debug.Log("Selected card attribute = " + selectedCard);
    }
    public void useCard(NPC target) { //applies card to NPC, sends card from hand --> discard pile
        discard = GameObject.Find("discardPile");
        selectedCardCardClass = selectedCard.GetComponent<Card>(); //this gets Card script features from gameobject
        selectedCardCardClass.cardEffect(target);
        DiscardPile discardPile = discard.GetComponent<DiscardPile>(); 
        discardPile.addCard(selectedCard.gameObject); //FIXME: at runtime the discard field is null for some reason????
        selectedCard.SetActive(false);
        //playerHand.removeCard(selectedCard);
        selectedCard = null;
        hasCard = false;
    }
}
