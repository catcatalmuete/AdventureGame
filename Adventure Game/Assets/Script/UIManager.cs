using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    
    public TextMeshProUGUI TempBuff;
    public TextMeshProUGUI NonDeath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PublicVars.diceRollModifier != 0) {
            TempBuff.text = "Next Dice Roll +" + PublicVars.diceRollModifier.ToString();
            //if (!PublicVars.instantDeath){
                //NonDeath.text = "Nondeath";
            //}
        }
    }
}
