using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawCard : MonoBehaviour
{
    public DrawPile drawPile;
    public GameObject playerArea;

    public void OnClick() {
        for (var i = 0; i < 5; ++i) {
            GameObject playerCard = Instantiate(drawPile.drawTopCard());
            playerCard.transform.SetParent(playerArea.transform, false);
        }
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
