using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomWhite : MonoBehaviour
{


    public GameObject[] rune;
    public GameObject[] runeUI;
    public GameObject sword;
    public GameObject swordUI;
    public GameObject hiddenWall;
    public GameObject swordOnRack;
    private bool[] runeCollect = {false, false};
    private bool hasSword = false;
    private int index;
    private int buffRoll;
    Collider _collider;

    

    
    // Start is called before the first frame update
    void Start()
    {
        swordUI.SetActive(false);
        swordOnRack.SetActive(false);
        runeUI[0].SetActive(false);
        runeUI[1].SetActive(false);
        _collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //pick up sword
        if (other.gameObject.CompareTag("WChest") && PublicVars.WOpen) 
        {
            index = int.Parse(other.gameObject.name);
            if (!runeCollect[index]){StartCoroutine(CollectRune(index));}
        } else if (other.gameObject.CompareTag("WShield") || other.gameObject.CompareTag("WCrate")) 
        {
            StartCoroutine(DisableTrigger());
        } else if (other.gameObject.CompareTag("WSword"))
        {
            //name = 1 = sword rack
            //name = 0 = sword
            if (!hasSword && int.Parse(other.gameObject.name) == 0){
                swordUI.SetActive(true);
                sword.SetActive(false);
                hasSword = true;
            } else if (hasSword && int.Parse(other.gameObject.name) == 1)
            {
                //name = 1 = is rack
                //if is rack & has Sword -> open door
                hiddenWall.SetActive(false);
                swordOnRack.SetActive(true);
                swordUI.SetActive(false);
            }
            
        }
    }


    IEnumerator CollectRune(int i)
    {
        yield return new WaitForSeconds(1f);
        rune[i].SetActive(false);

        runeCollect[i] = true;
        runeUI[i].SetActive(true);
        yield return new WaitForSeconds(0.5f);
            //run diceRoll in diceRoll

        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<DiceRoll>().Roll();
        yield return new WaitForSeconds(5f);
        buffRoll = PublicVars.diceVal;
        //PublicVars.diceRollModifier += buffRoll;
        if (buffRoll >=6){
            //get diceRoll buff +2
            PublicVars.diceRollModifier += 1;
        }

    }

    IEnumerator DisableTrigger()
    {
        _collider.isTrigger = false;
        yield return new WaitForSeconds(0.5f);
        _collider.isTrigger = true;
    }
}
