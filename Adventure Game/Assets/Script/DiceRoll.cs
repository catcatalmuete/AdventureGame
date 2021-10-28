using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject diceCam;
    //public int CamMode;

    private GameObject spawnPoint = null;


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
        if (other.gameObject.CompareTag("DiceRoll")) 
        {
            StartCoroutine(RollDice());
        }
    }

    IEnumerator RollDice(){
        yield return new WaitForSeconds(0.01f);
        diceCam.SetActive(true);
        mainCam.SetActive(false);
        Dice.Clear();
        Dice.Roll("1d6", "d6-black", spawnPoint.transform.position, Force());
        Dice.Roll("1d6", "d6-black", spawnPoint.transform.position, Force());

        //Dice.Value("") to access the sum of diceroll
        if (Dice.Value("") > 0){
            yield return new WaitForSeconds(4.0f);
            diceCam.SetActive(false);
            mainCam.SetActive(true);
        }

    }

    private Vector3 Force()
    {
        //Vector3 rollTarget = Vector3.zero + new Vector3(2 + 7 * Random.value, .5F + 4 * Random.value, -2 - 3 * Random.value);
        //return Vector3.Lerp(spawnPoint.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20);
        Vector3 rollTarget = Vector3.zero;
        return Vector3.Lerp(spawnPoint.transform.position, rollTarget, 1).normalized * (-35 - Random.value * 20);
    }


}
