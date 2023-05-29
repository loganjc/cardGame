using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
public Transform[] pileSpots; //use these to place the piles on init
//[SerializeField] GameObject PlacementObj;
[SerializeField] public static Deck playerDeck;
DrawPile drawPile;
DiscardPile discardPile;
PlayerHand playerHand;

public void initDrawPile() {
    drawPile = new DrawPile(playerDeck);
    drawPile.gameObject.SetActive(true);
    drawPile.transform.position = pileSpots[0].position;
}

public void initDiscardPile() {
    discardPile = new DiscardPile();
    discardPile.gameObject.SetActive(true);
    discardPile.transform.position = pileSpots[1].position;
}

public void initPlayerHand() {
    playerHand = new PlayerHand();
}

    // Start is called before the first frame update
    void Start()
    {
        initDrawPile();
        initPlayerHand();
        initDiscardPile();
        //set references? aka give the pile object references to eachother so their internal methods work right
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
