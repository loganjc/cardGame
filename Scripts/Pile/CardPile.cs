using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    public static List<GameObject> cards = new List<GameObject>();
    public int cardCount = 0;
    public bool isEmpty;

    public GameObject removeCard(GameObject cardToRemove) {
        cards.Remove(cardToRemove);
        --this.cardCount;
        Debug.Log(cardToRemove + " removed from " + this);
        return cardToRemove; 
    }

    public void addCard(GameObject cardToAdd) {
        cards.Add(cardToAdd);
        ++cardCount;
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

    public void printCards() { //print all cards in draw to console
        for(int i = 0; i < cardCount; i++) {
            Debug.Log(cards[i].name);
        }
    }
}
