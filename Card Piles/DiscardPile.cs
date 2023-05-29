using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : CardPile
{
    //static List<Card> discardedCards;

    static public void insertCard(Card playedCard) {
        cards.Add(playedCard);
        Debug.Log(playedCard + "now in discard");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
