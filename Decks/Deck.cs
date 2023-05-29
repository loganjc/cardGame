using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{ //this is the class to store all player cards. Draw/ discard pile should inherit this

    public List<Card> playerCards = new List<Card>();
    public int cardCount;

    public Card removeCard(Card cardToRemove) {
        playerCards.Remove(cardToRemove);
        return cardToRemove;
    }

    public void addCard(Card cardToAdd) {
        playerCards.Add(cardToAdd);
    }

    public void updateCard(Card currentCard, Card newCard) {
        playerCards.Remove(currentCard);
        playerCards.Add(newCard);
    }

    public List<Card> getCopy() {
        List<Card> copy = new List<Card>(playerCards);
        return copy;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
