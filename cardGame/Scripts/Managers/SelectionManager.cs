using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Responsible for selecting cards in hand, applying cards to characters
    Selection manager 
    FIXME: needs to be able to apply to PC
*/
public class SelectionManager : MonoBehaviour
{
    public static bool hasCard = false;
    public GameObject selectedCard;
    public GameObject PC_gameObj;
    public GameObject discard;
    public GameObject hand;
    private Card selectedCardCardClass; 
    public PlayerCharacter PC;
    public DiscardPile discardPile;
    public PlayerHand playerHand;
    public TurnManager TM;
    public List<NPC> NPCs;

    //----------------------------------------------------------------
    //Manager methods
    public bool getHasCard() {
        return hasCard;
    }
    public void cardSelect(GameObject playerCard) { //method stores clicked on card for clicking card application method
        selectedCard = playerCard;
        hasCard = true;
    }

    //-------------------------------------------------------------------
    //Card effect application methods:
    //  These methods apply cards to various targets based on card targeting scheme: single target, AOE, self, etc.
    //  Methods are called by the associated dragdrop methods present on card gameobjects.
    public void useCard(Character target) { //applies card to single NPC, sends card from hand --> discard pile
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

    public void applyAOE() { //applies card to ALL npcs, sends card from hand --> discard pile
        getObjRefs();
        NPCs = TM.getNPCs();
        selectedCardCardClass = selectedCard.GetComponent<Card>();
        if (PC.getEnergy() >= selectedCardCardClass.cost) {
            for(int i = 0; i < NPCs.Count; ++i) {
                selectedCardCardClass.useCard(NPCs[i]); //FIXME: this is causing PC energy to go negative
            }
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

    public void applyToPC() {

    }

//----------------------------------------------------------
//Setup methods
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

    public void Awake() {
        TM = GameObject.Find("turnManager").GetComponent<TurnManager>();
    }
}
