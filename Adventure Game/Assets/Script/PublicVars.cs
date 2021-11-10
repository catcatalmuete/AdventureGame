using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVars : MonoBehaviour
{
    //updated after each roll, will be updated after buffs/debuffs are applied
    public static int diceVal = 0;
    public static bool instantDeath = true;
    //sum all buffs/debuffs the player has
    public static int diceRollModifier = 0;
    //strikes occurred in the green room
    public static int numStrikes = 0;
    //num of tiles lit up in red room for each puzzle
    public static int numTilesMand = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
}
