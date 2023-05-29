using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Transform[] cardSlots; //card slots are where the in hand cards go
    public bool[] availableCardSlots; //array of open card slots
    public Text deckSizeText;
    
    public void DrawCard(){ //method to draw card from deck
        if(deck.Count >= 1) {
            Card randCard = deck[Random.Range(0, deck.Count)];

            for(int i = 0; i < availableCardSlots.Length; i++){ //loop through card slots
                if(availableCardSlots[i] == true) { //if CS is open, activate a rand card +  place it in the slot
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    return;
                }
            }
        }
    }//end draw card

    private void Update() {
        deckSizeText.text = deck.Count.ToString();
    }
}
