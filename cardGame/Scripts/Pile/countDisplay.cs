using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class countDisplay : MonoBehaviour
{
    public TextMeshProUGUI cardCountDisplay;
    public CardPile pile;

    public void updateCardCountDisplay() {
        cardCountDisplay.text = pile.cardCount.ToString(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        cardCountDisplay.text = pile.cardCount.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
