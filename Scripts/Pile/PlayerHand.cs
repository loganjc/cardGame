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
