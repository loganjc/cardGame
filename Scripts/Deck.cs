using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{ //this is the class to store all player cards. Draw/ discard pile should inherit this

    public List<GameObject> playerCards = new List<GameObject>();
    public int cardCount;

    public GameObject removeCard(GameObject cardToRemove) {
        playerCards.Remove(cardToRemove);
        return cardToRemove;
    }

    public void addCard(GameObject cardToAdd) {
        playerCards.Add(cardToAdd);
    }

    public void updateCard(GameObject currentCard, GameObject newCard) {
        playerCards.Remove(currentCard);
        playerCards.Add(newCard);
    }

    public List<GameObject> getCopy() {
        List<GameObject> copy = new List<GameObject>(playerCards);
        return copy;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
