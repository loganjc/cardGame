using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
public static Deck playerDeck;
public DrawPile drawPile;
public DiscardPile discardPile;
public GameObject playerHandGO;
public PlayerHand playerHand;
public PlayerCharacter PC;
public List<NPC> NPCs;

//------------------------------------------------------------------------------------
//Turn Managers
public void startCombat() { //Inits piles and hand
    //spawn enemies?? **
    drawPile.buildDrawPile();
    drawStartCards();
}

public void startPCTurn() { //resets PC energy, def, applies statuses, draw cards
    //apply status effects**
    //tick down status effects?**
    PC.restoreEnergy();
    PC.resetDefense();
    drawStartCards();
}

public void endPCTurn() { //discard hand, Status effects, NPC turn
    emptyHand();
    //apply status effects
    //start NPC turn **
    startPCTurn();
}
//--------------------------------------------------------------------------------------
//Card Draw
public void drawStartCards() { //draw 5 cards from draw --> hand
        for (var i = 0; i < 5; ++i) {
            drawCard();
        }
    }
public void drawCard() { //draw a single card from draw --> hand
    if (drawPile.cardCount == 0) {
        discardToDraw();
    }
    GameObject playerCard = drawPile.drawTopCard();  
    playerCard.transform.SetParent(playerHandGO.transform, false);
    playerCard.SetActive(true);
    playerHand.addCard(playerCard);
    drawPile.cardCountDisplay.updateCardCountDisplay();
}
//------------------------------------------------------------------------------------
//Piles/ Card Managers
public void discardToDraw() { //send cards from discard --> draw + shuffle draw
    while (discardPile.cardCount > 0) {
        GameObject topcard = discardPile.drawTopCard();
        topcard.SetActive(true);
        drawPile.addCard(topcard);
    }
    drawPile.shuffle();
}

public void discardOneCard() {
    GameObject selectedCard = playerHand.drawTopCard(); //FIXME: the null reference exception is here, it does not print log msgs, 
                                                        //does remove a card from hand though.... 
    discardPile.addCard(selectedCard);
    selectedCard.SetActive(false);
    selectedCard.transform.SetParent(null, false);
    selectedCard.transform.position = new Vector2(-100, -100);
}

public void emptyHand() { //send all cards from hand --> discard
    while (playerHand.cardCount > 0) {
        discardOneCard();
    }
}

//------------------------------------------------------------------------------------
//Setup
public void getObjRefs() { //grab needed GO references from unity scene
    GameObject drawPileGO = GameObject.Find("drawPile");
    drawPile = drawPileGO.GetComponent<DrawPile>();
    playerHandGO = GameObject.Find("playerHandArea");
    playerHand = playerHandGO.GetComponent<PlayerHand>();
    GameObject discardPileGO = GameObject.Find("discardPile");
    discardPile = discardPileGO.GetComponent<DiscardPile>();
    GameObject PC_GO = GameObject.Find("PlayerCharacter");
    PC = PC_GO.GetComponent<PlayerCharacter>();
}

    // Start is called before the first frame update
    void Start()
    {
        getObjRefs();
        //startCombat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
