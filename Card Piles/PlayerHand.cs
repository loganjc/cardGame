using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : CardPile
{
    [SerializeField] DiscardPile discardPile;
    [SerializeField] DrawPile drawPile;

    static List<Card> playerHandCards;

    public static void drawCard() {
        DrawPile.drawTopCard();
    }

    public static void toDiscard(Card playedCard) {
        DiscardPile.insertCard(playedCard);
        playerHandCards.Remove(playedCard);
        Debug.Log(playedCard + "gone from player hand");
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
