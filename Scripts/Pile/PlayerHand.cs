using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : CardPile
{
    public DiscardPile discardPile;
    public DrawPile drawPile;

    static List<Card> playerHandCards;

    public void updateCardCount() {
        this.cardCount = playerHandCards.Count;
    }

    new public GameObject removeCard(GameObject cardToRemove) {
        cards.Remove(cardToRemove);
        --this.cardCount;
        Debug.Log(cardToRemove + " removed from " + this);
        return cardToRemove; 
    }

    new public void addCard(GameObject cardToAdd) {
        cards.Add(cardToAdd);
        ++cardCount;
        Debug.Log(cardToAdd + " added to " + this);
    }

    // public static void drawCard() {
    //     DrawPile.drawTopCard();
    // }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
