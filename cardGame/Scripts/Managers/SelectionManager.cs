using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Responsible for selecting cards in hand, applying cards to NPC
    FIXME: needs to be able to apply to PC
    FIXME: add drag + drop behavior */
public class SelectionManager : MonoBehaviour
{
    public static bool hasCard = false;
    public GameObject selectedCard;
    private Card selectedCardCardClass; 
    public GameObject PC_gameObj;
    public PlayerCharacter PC;
    public GameObject discard;
    public DiscardPile discardPile;
    public GameObject hand;
    public PlayerHand playerHand;

    //----------------------------------------------------------------
    public bool getHasCard() {
        return hasCard;
    }
    public void cardSelect(GameObject playerCard) { //
        selectedCard = playerCard;
        hasCard = true;
    }
    public void useCard(Character target) { //applies card to NPC, sends card from hand --> discard pile
        getObjRefs();
        selectedCardCardClass = selectedCard.GetComponent<Card>();
        if (PC.getEnergy() >= selectedCardCardClass.cost) {
            selectedCardCardClass.useCard(target);
            discardPile.addCard(selectedCard.gameObject);
            playerHand.removeCard(selectedCard);
            selectedCard.SetActive(false);
            selectedCard.transform.SetParent(null, false);
            selectedCard.transform.position = new Vector2(-100, -100);
            selectedCard = null;
            hasCard = false;
        }
        else {
            Debug.Log("You don't have enough energy to play " + selectedCard);
            selectedCard = null;
            hasCard = false;
        }
    }

    public void getObjRefs() { //this is to try and fix null object exceptions...
        if (!discard) {
            discard = GameObject.Find("discardPile");
        }
        if (!hand) {
            hand = GameObject.Find("playerHandArea");
        }
        if (!discardPile) {
                discardPile = discard.GetComponent<DiscardPile>(); 
            }
        if (!playerHand) {
            playerHand = hand.GetComponent<PlayerHand>();
        }
        if (!PC_gameObj) {
            PC_gameObj = GameObject.Find("PlayerCharacter");
        }
        if (!PC) {
            PC = PC_gameObj.GetComponent<PlayerCharacter>();
        }
    }

    public void Start() {
        
    }
}
