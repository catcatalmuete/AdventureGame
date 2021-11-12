using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomOrange : MonoBehaviour
{
    private int candleCollectCount = 0;
    private int trueCount = 0; //number of candle lighted up on the torch post
    public GameObject[] candles;
    public GameObject[] inventoryC;
    public GameObject chest;
    public GameObject rune;
    public GameObject runeUI;
    public GameObject extraRuneUI;
    private int index;
    private int buffRoll;
    private bool runeCollect = false;
    public bool[] TorchPostLight = {false, false, false, false};
    

    
    // Start is called before the first frame update
    void Start()
    {
        runeUI.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            candles[i].SetActive(false);
            inventoryC[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i < candleCollectCount) {inventoryC[i].SetActive(true);}
            else {inventoryC[i].SetActive(false);}
        }
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
            if (!TorchPostLight[index])
            {
                candles[index].SetActive(true);
                TorchPostLight[index] = true;
                candleCollectCount -= 1;
                trueCount += 1;

                if (trueCount == 4){ StartCoroutine(OpenChest());}
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
        runeUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
            //run diceRoll in diceRoll

        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<DiceRoll>().Roll();
        yield return new WaitForSeconds(5f);
        buffRoll = PublicVars.diceVal;
        //PublicVars.diceRollModifier += buffRoll;
        if (buffRoll <=1){
            //get diceRoll buff +2
            PublicVars.diceRollModifier += 2;
        } else if (buffRoll <=9){
            //get avoid instant death buff
            PublicVars.instantDeath = false;
        } else {
            extraRuneUI.SetActive(true);
        }

    }
}
