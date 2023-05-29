using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private int HP;
    private int maxHP;
    private int energy;
    private int maxEnergy;
    private int handLimit;
    private int defense;

    public void takeDamage(int damage) {
        HP = HP - damage;
    }

    public void heal(int heal) {
        HP = HP + heal;
        if (HP > maxHP) {
            HP = maxHP;
        }
    }

    public void useEnergy(int energyCost) {
        energy = energy - energyCost;
    }

    public void restoreEnergy() {
        energy = maxEnergy;
    }

    public void addDefense(int defenseValue) {
        defense = defense + defenseValue;
    }

    public void resetDefense() {
        defense = 0;
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
