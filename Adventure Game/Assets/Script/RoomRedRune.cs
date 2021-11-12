using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRedRune : MonoBehaviour
{

    public GameObject[] runeUI;
    private int index = 0;
    private int buffRoll;
    // Start is called before the first frame update
    void Start()
    {
        runeUI[0].SetActive(false);
        runeUI[1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //pick up sword
        if (other.gameObject.CompareTag("RRune"))
        {
            other.gameObject.SetActive(false);
            runeUI[index].SetActive(true);
            index += 1;
            StartCoroutine(CollectRune());
        }
    }
    IEnumerator CollectRune()
    {
        yield return new WaitForSeconds(1f);

        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<DiceRoll>().Roll();
        yield return new WaitForSeconds(5f);
        buffRoll = PublicVars.diceVal;
        //PublicVars.diceRollModifier += buffRoll;
        if (buffRoll >=6){
            //get diceRoll buff +2
            PublicVars.diceRollModifier += 1;
        }

    }
}
