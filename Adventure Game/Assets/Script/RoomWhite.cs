using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomWhite : MonoBehaviour
{


    public GameObject[] rune;
    public GameObject[] runeUI;
    private bool[] runeCollect = {false, false};
    private int index;
    private int buffRoll;
    Collider _collider;

    

    
    // Start is called before the first frame update
    void Start()
    {
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
        }else if (other.gameObject.CompareTag("Shield") || other.gameObject.CompareTag("WCrate")) {StartCoroutine(DisableTrigger());}
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
        if (buffRoll <=5){
            //get diceRoll buff +2
            PublicVars.diceRollModifier += 1;
        }

    }

    IEnumerator DisableTrigger()
    {
        _collider.isTrigger = false;
        yield return new WaitForSeconds(2f);
        _collider.isTrigger = true;
    }
}
