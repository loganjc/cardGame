using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DrawPile : CardPile
{
    public Deck playerDeck;

    public DrawPile(Deck playerDeck) { //constructor for object. Not used currently
        cards = playerDeck.getCopy();
        cardCount = cards.Count;
        this.playerDeck = playerDeck;
        this.shuffle();
        //FIXME: insert call to update UI elements with card count
    }

    public void shuffle() { //shuffle draw pile for start of round/ init/ card effects, etc
        for(int i = 0; i < cardCount; i++) {
           Card currentCard = cards[i].GetComponent<Card>(); 
           currentCard.shuffleNumber = Random.Range(0, 100);
           Debug.Log(currentCard + " shuffle no: " + currentCard.shuffleNumber);
        }
        cards = cards.OrderBy(c => c.GetComponent<Card>().shuffleNumber).ToList();
        Debug.Log("Draw pile shuffled.");
    }

    public void buildDrawPile() { 
        cards = playerDeck.getCopy();
        this.cardCount = cards.Count;
        Debug.Log("Draw pile has " + this.cardCount + " cards");
    }   
    

    public bool isEmpty(){
        return cardCount == 0;
    }
}
