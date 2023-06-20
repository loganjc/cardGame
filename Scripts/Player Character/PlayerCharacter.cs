using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This is the Player Character Class. It stores player stats, status effects, etc.
    Other methods will need call the methods in this class to interact with PC.
*/
public class PlayerCharacter : MonoBehaviour
{
    private int HP;
    private int maxHP;
    private int energy = 3; //FIXME: something is fucked with this and the selectionManager comparison to cost
    private int maxEnergy = 3;
    private int handLimit;
    private int defense = 0;
    public SelectionManager selectionManager;
    public EnergyDisplay energyUIDisplay;

    public void takeDamage(int damage) {
        damage = defense - damage;
        if ( damage > 0) {
            HP = HP - damage;
        }
    }

    public void heal(int heal) {
        HP = HP + heal;
        if (HP > maxHP) {
            HP = maxHP;
        }
    }

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
