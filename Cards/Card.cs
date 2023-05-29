using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : MonoBehaviour
{
    [SerializeField] public new string name;
    [SerializeField] public string description;
    [SerializeField] public Sprite cardImage;
    [SerializeField] public int cost;
    [SerializeField] private GameObject _highlight;
    [SerializeField] public GameObject _thisButton;
    public bool inDraw;
    public bool inHand;
    public bool inDiscard;
    public bool isSelected = false;
    public int shuffleNumber;

    void OnMouseEnter() {
        _highlight.SetActive(true);
    }

    void OnMouseExit() {
        _highlight.SetActive(false);
    }

    public void OnMouseDown(){
        isSelected = true;
        SelectionManager.cardSelect(this);
        Debug.Log("Clicked on " + this);
    }

    public void cardEffect(NPC selectedNPC){
        selectedNPC.takeDamage(1);
        //card effects
    }
}
