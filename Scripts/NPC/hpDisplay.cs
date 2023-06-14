using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hpDisplay : MonoBehaviour
{
    public TextMeshProUGUI hpDisplayUI;
    public NPC enemy;

    // Start is called before the first frame update
    public void updateHPcounter(int HP) {
        hpDisplayUI.text = HP.ToString();
    }

    void Start()
    {
        hpDisplayUI.text = enemy.HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
