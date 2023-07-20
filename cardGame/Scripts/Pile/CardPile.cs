using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();
    public int cardCount = 0;
    public bool isEmpty;
    public countDisplay cardCountDisplay;

    public GameObject removeCard(GameObject cardToRemove) { // this method is used to remove cards from card piles
        cards.Remove(cardToRemove);
        --this.cardCount;
        if (cardCount == 0) {
            isEmpty = true;
        }
        cardCountDisplay.updateCardCountDisplay();
        //Debug.Log(cardToRemove + " removed from " + this);
        return cardToRemove; 
    }

    public void addCard(GameObject cardToAdd) { //this method is used to transfer cards between piles
        cards.Add(cardToAdd);
        ++cardCount;
        isEmpty = false;
        cardCountDisplay.updateCardCountDisplay();
        //Debug.Log(cardToAdd + " added to " + this);
    }

    public void updateCard(GameObject currentCard, GameObject newCard) {
        cards.Remove(currentCard);
        cards.Add(newCard);
    }

    public List<GameObject> copyCards() { //returns a copy of the cards currently in the card pile
        List<GameObject> copy = new List<GameObject>(cards);
        return copy;
    }


    public GameObject drawTopCard() { //return top card of cards in cards array + remove from array, otherwise return null
        if (this.cardCount == 0) {
            Debug.Log(this + " is empty!");
            return null;
        }
        else {
        GameObject pulledCard =  cards[0];
        this.removeCard(pulledCard);  
        return pulledCard;
        }
    }

    public void printCards() { //print all cards in pile to console
        for(int i = 0; i < cardCount; i++) {
            Debug.Log(this + " " + cards[i].name);
        }
    }
}
