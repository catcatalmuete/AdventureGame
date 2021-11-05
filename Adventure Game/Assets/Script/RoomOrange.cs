using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomOrange : MonoBehaviour
{
    private int candleCollectCount = 0;
    private int trueCount = 0; //number of candle lighted up on the torch post
    public GameObject[] candles;
    public GameObject chest;
    public GameObject rune;
    private int index;
    private int buffRoll;
    private bool runeCollect = false;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            candles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Candle")) 
        {
            other.gameObject.SetActive(false);
            candleCollectCount += 1;
        } else if (other.gameObject.CompareTag("TorchPost") && candleCollectCount > 0)
        {
            index = int.Parse(other.gameObject.name);
            candles[index].SetActive(true);
            candleCollectCount -= 1;
            trueCount += 1;
            //update UI

            if (trueCount == 4)
            {
                StartCoroutine(OpenChest());
            }
        } else if (other.gameObject.CompareTag("OChest") && trueCount == 4 && !runeCollect)
        {
            StartCoroutine(CollectRune());
        }
    }

    IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1f);
        //play sound
        chest.GetComponent<Animation>().Play("ChestAnim");

    }

    IEnumerator CollectRune()
    {
        yield return new WaitForSeconds(1f);

        rune.SetActive(false);
        runeCollect = true;
            //add rune to UI
            //run diceRoll in diceRoll

        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<DiceRoll>().Roll();
        buffRoll = PublicVars.diceVal;
        if (buffRoll <=6){
            //get diceRoll buff +2
            PublicVars.diceRollModifier += 2;
        } else {
            //get avoid instant death buff
            PublicVars.instantDeath = false;
        }

    }
}
