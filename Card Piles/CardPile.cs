using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile : MonoBehaviour
{
    public static List<Card> cards = new List<Card>();
    public int cardCount;
    public bool isEmpty;

    public Card removeCard(Card cardToRemove) {
        cards.Remove(cardToRemove);
        return cardToRemove;
    }

    public void addCard(Card cardToAdd) {
        cards.Add(cardToAdd);
    }

    public void updateCard(Card currentCard, Card newCard) {
        cards.Remove(currentCard);
        cards.Add(newCard);
    }

    public List<Card> copyCards() {
        List<Card> copy = new List<Card>(cards);
        return copy;
    }

    public void toDiscard() {}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
