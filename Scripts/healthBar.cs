using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void setMaxHp(int HP) { //initalize HP bar slider values
        slider.maxValue = HP;
        slider.value = HP;
    }
    public void setHp(int HP) { //update slider bar amount
        slider.value = HP;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
