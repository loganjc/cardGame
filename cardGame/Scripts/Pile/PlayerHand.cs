using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : CardPile
{
    public DiscardPile discardPile;
    public DrawPile drawPile;


    new public GameObject removeCard(GameObject cardToRemove) {
        cards.Remove(cardToRemove);
        --cardCount;
        //Debug.Log(cardToRemove + " removed from " + this);
        return cardToRemove; 
    }

    new public void addCard(GameObject cardToAdd) { //method without count display update
        cards.Add(cardToAdd);
        ++cardCount;
        //Debug.Log(cardToAdd + " added to " + this);
    }

    new public GameObject drawTopCard() { //return top card if cards in list, otherwise return null
        //Debug.Log("Player hand card count: " + cardCount);
        if (cardCount == 0) {
            Debug.Log("Player hand is empty!");
            return null;
        }
        else {
            //Debug.Log("pulling top card from player hand");
            GameObject pulledCard =  cards[0];
            removeCard(pulledCard);  
            return pulledCard;
        }
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
