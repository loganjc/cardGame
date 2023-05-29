using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardManager : MonoBehaviour
{
    public  DrawPile drawPile;
    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public void drawCard() {
        if (drawPile.cardCount >= 1) { // call method on draw pile to take top card
            Card topCard = DrawPile.drawTopCard();

            for (int i = 0; i < availableCardSlots.Length; i++) { //activate card, place in available hand card slot
                if (availableCardSlots[i] == true) {
                    topCard.gameObject.SetActive(true);
                    topCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    return;
                }
            }
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
