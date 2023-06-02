using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private int HP = 10;
    private int maxHP;
    private int handLimit;
    private int defense;
    public SelectionManager selectionManager;

    public void OnMouseDown() {
        Debug.Log("clicked on " + name);
        if (selectionManager.getHasCard() == true) {
            selectionManager.useCard(this);
            Debug.Log("used a card on " + name);
        }
    }

    public void takeDamage(int damage) {
        Debug.Log("NPC took " + damage + " damage");
        HP -= damage;
        Debug.Log("NPC has " + HP + " HP");
        if (HP <= 0){
            Destroy(this);
            Debug.Log("NPC has been destroyed");
        }
    }

    public void heal(int heal) {
        HP = HP + heal;
        if (HP > maxHP) {
            HP = maxHP;
        }
    }

    public void addDefense(int defenseValue) {
        defense = defense + defenseValue;
    }

    public void resetDefense() {
        defense = 0;
    }

    public void printHP(){
        print(HP);
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
