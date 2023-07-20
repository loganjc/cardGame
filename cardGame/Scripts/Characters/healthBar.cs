using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class healthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    public TextMeshProUGUI defenseText;
    public GameObject defenseIcon;

    public void setMaxHp(int HP) { //initalize HP bar slider values
        slider.maxValue = HP;
        slider.value = HP;
        text.text = HP.ToString();
    }
    public void setHp(int HP) { //update slider bar amount
        slider.value = HP;
        text.text = HP.ToString();
    }
    public void updateDefense(int defenseVal) {
        defenseText.text = defenseVal.ToString();
        if (defenseVal > 0) {
            defenseIcon.SetActive(true);
        }
        else {
            defenseIcon.SetActive(false);
        }

    }
}
