using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DrawPile : CardPile
{
    public Deck playerDeck;

    public DrawPile(Deck playerDeck) { //constructor for object. Called by Turn Manager
        cards = playerDeck.getCopy();
        cardCount = cards.Count;
        this.playerDeck = playerDeck;
        this.shuffle();
        //FIXME: insert call to update UI elements with card count
    }

    private void shuffle() { //shuffle draw pile for start of round/ init/ card effects, etc
        for(int i = 0; i < cardCount; i++) {
           // cards[i].shuffleNumber = Random.Range(0, 100);
        }
        cards.Sort();  //FIXME: make the sort go by card.shuffleNumber attribute
        //reset suffle number?
    }

    public void buildDrawPile() { 
        cards = playerDeck.getCopy();
        this.cardCount = cards.Count;
        Debug.Log("Draw pile has " + this.cardCount + " cards");
    }   


    public GameObject drawTopCard() {
        GameObject pulledCard =  cards[0];
        cards.Remove(pulledCard);
        --this.cardCount;
        return pulledCard;
    }

    public bool isEmpty(){
        return cardCount == 0;
    }
}
