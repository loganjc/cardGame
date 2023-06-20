using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public int HP = 10;
    private int maxHP;
    private int handLimit;
    private int defense;
    public healthBar hpBar;
    public hpDisplay hpDisplayUI;
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
        hpDisplayUI.updateHPcounter(this.HP);
        hpBar.setHp(HP);
        Debug.Log("NPC has " + HP + " HP");
        if (HP <= 0){
            death();
        }
    }

    public void death(){
        this.gameObject.SetActive(false);
        Destroy(this);
            Debug.Log("NPC has been destroyed");
    }

    public void heal(int heal) {
        HP = HP + heal;
        if (HP > maxHP) {
            HP = maxHP;
        }
        hpBar.setHp(HP);
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
        hpBar.setMaxHp(HP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
