using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawCard : MonoBehaviour
{
    public DrawPile drawPile;
    public GameObject playerArea;

    public void OnClick() {
        PlayerHand playerHand = playerArea.GetComponent<PlayerHand>();
        for (var i = 0; i < 5; ++i) {
            //FIXME LATER: finished method needs check on drawPile.cardCount to shuffle discard to draw when needed.
            //GameObject playerCard = Instantiate(drawPile.drawTopCard()); //this might be an issue: it is creating cards. 
            GameObject playerCard = drawPile.drawTopCard();  
            playerCard.transform.SetParent(playerArea.transform, false);
            playerCard.SetActive(true);
            playerHand.addCard(playerCard);
        }
        drawPile.cardCountDisplay.updateCardCountDisplay();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerArea = GameObject.Find("playerHandArea");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
