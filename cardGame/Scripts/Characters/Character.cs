using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int HP = 10;
    public int maxHP = 10;
    public int energy = 3;
    public int maxEnergy = 3;
    public int defense = 0;
    public SelectionManager selectionManager;
    public EnergyDisplay energyUIDisplay;
    public healthBar hpBar;


//-----------------------------------------------------
    //Damage + HP methods
    public void takeDamage(int damage) {
        damage = damage - defense;
        defense = defense - damage;
        if (defense < 0) {
            defense = 0;
        }
        if ( damage > 0) {
            HP = HP - damage;
        }
        hpBar.updateDefense(defense);
        hpBar.setHp(HP);
        Debug.Log(this + " has " + HP + " HP");
        if (HP <= 0){
            death();
        }
    }

    public void heal(int heal) {
        HP = HP + heal;
        if (HP > maxHP) {
            HP = maxHP;
        }
        hpBar.setHp(HP);
    }

    public virtual void death() { } //death override methods in PlayerCharacter and NPC classes

//------------------------------------------------------
    //Energy Methods
    public int getEnergy() {
        return energy;
    }
    public int getMaxEnergy() {
        return maxEnergy;
    }

    public void removeEnergy(int energyCost) {
        energy = energy - energyCost;
        energyUIDisplay.updateEnergyCount(energy);        
    }

    public void addEnergy(int energyToAdd) {
        energy = energy + energyToAdd;
        energyUIDisplay.updateEnergyCount(energy);
    }

    public void restoreEnergy() {
        energy = maxEnergy;
        energyUIDisplay.updateEnergyCount(energy);
    }

//------------------------------------------------------
    //Defense Methods
    public void addDefense(int defenseValue) {
        this.defense = this.defense + defenseValue;
        hpBar.updateDefense(defense);
        Debug.Log(this + " added defense");
    }

    public void resetDefense() {
        defense = 0;
        hpBar.updateDefense(defense);
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
