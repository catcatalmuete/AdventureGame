using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject diceCam;
    //public int CamMode;

    private GameObject spawnPoint = null;
    public bool teleport = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("spawnPointDice");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DiceRoll") || other.gameObject.CompareTag("Teleport"))
        {
            StartCoroutine(RollDice());
            teleport = true;
        }
    }

    IEnumerator RollDice()
    {
        yield return new WaitForSeconds(0.01f);
        diceCam.SetActive(true);
        mainCam.SetActive(false);
        Dice.Clear();
        Dice.Roll("1d6", "d6-black", spawnPoint.transform.position, Force());
        Dice.Roll("1d6", "d6-black", spawnPoint.transform.position, Force());

        //Dice.Value("") to access the sum of diceroll
        if (Dice.Value("") > 0)
        {
            yield return new WaitForSeconds(4.0f);
            diceCam.SetActive(false);
            mainCam.SetActive(true);

            //set diceVal with buff/debuff
            PublicVars.diceVal = Dice.Value("") + PublicVars.diceRollModifier;
            //comment out nextline if you do not want buff/debuff to be one-time only
            PublicVars.diceRollModifier = 0;

            //except teleport, if want to call diceroll in other script
            //use GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<DiceRoll>().Roll() to roll the dice
            //use PublicVars.diceVal to access diceroll value

            if (teleport){
                GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMove>().Teleport(PublicVars.diceVal);
                teleport = false;
            }
        }

    }

    private Vector3 Force()
    {
        //Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
        //return Vector3.Lerp(spawnPoint.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20);
        Vector3 rollTarget = Vector3.zero + new Vector3(0.3f * Random.value, 0.3f - 0.3f * Random.value, 0);
        return Vector3.Lerp(spawnPoint.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20);
    }

    //to be called in other functions
    //except teleport, if want to call diceroll in other script
    //use GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<DiceRoll>().Roll() to roll the dice
    //use PublicVars.diceVal to access diceroll value
    public void Roll(){
        StartCoroutine(RollDice());
    }

}
