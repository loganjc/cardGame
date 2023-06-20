using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyDisplay : MonoBehaviour
{
    public PlayerCharacter PC;
    public TextMeshProUGUI displayText;
    public int maxEnergy;
    // Start is called before the first frame update
    void Start()
    {
        maxEnergy = PC.getMaxEnergy();
        displayText.text = maxEnergy.ToString();
    }

    public void updateEnergyCount(int energy) {
        displayText.text = energy.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
