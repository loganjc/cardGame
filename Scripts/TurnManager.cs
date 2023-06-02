using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
public Transform[] pileSpots; //use these to place the piles on init
//[SerializeField] GameObject PlacementObj;
[SerializeField] public static Deck playerDeck;
public DrawPile drawPile;
public DiscardPile discardPile;
public PlayerHand playerHand;



public void getStartHand() {
    int i = 0;
    while (i < 5) {
        //cardManager.drawCard();
        ++i;
    }
}

public void setReferences() {
    
}

    // Start is called before the first frame update
    void Start()
    {
        // initDrawPile();
        // initPlayerHand();
        // initDiscardPile();
        // setReferences();
        //getStartHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
