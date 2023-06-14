using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class endOfTurnDiscardToDraw : MonoBehaviour
{
public DrawPile drawPile;
public DiscardPile discardPile; 

public void endOfTurn() { //send cards from discard to draw + shuffle draw
    while (discardPile.cardCount > 0) {
        GameObject topcard = discardPile.drawTopCard();
        topcard.SetActive(true);
        drawPile.addCard(topcard);
    }
    drawPile.shuffle();
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
