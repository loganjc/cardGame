using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    public static List<GameObject> cards = new List<GameObject>();
    public int cardCount = 0;
    public bool isEmpty;
    public countDisplay cardCountDisplay;

    public GameObject removeCard(GameObject cardToRemove) {
        cards.Remove(cardToRemove);
        --this.cardCount;
        cardCountDisplay.updateCardCountDisplay();
        Debug.Log(cardToRemove + " removed from " + this);
        return cardToRemove; 
    }

    public void addCard(GameObject cardToAdd) {
        cards.Add(cardToAdd);
        ++cardCount;
        cardCountDisplay.updateCardCountDisplay();
        Debug.Log(cardToAdd + " added to " + this);
    }

    public void updateCard(GameObject currentCard, GameObject newCard) {
        cards.Remove(currentCard);
        cards.Add(newCard);
    }

    public List<GameObject> copyCards() {
        List<GameObject> copy = new List<GameObject>(cards);
        return copy;
    }

    public GameObject drawTopCard() { //draws top card if cards in list, otherwise return null
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

    public void printCards() { //print all cards in draw to console
        for(int i = 0; i < cardCount; i++) {
            Debug.Log(this + " " + cards[i].name);
        }
    }
}
