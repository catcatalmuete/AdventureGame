using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeStrikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            int curStrikes = PublicVars.numStrikes;
            if (curStrikes < 2){
                PublicVars.numStrikes = curStrikes + 1;
            }
            else {
                PublicVars.numStrikes = 0;
                //teleport
                other.GetComponent<DiceRoll>().Roll();
                //greenUI.SetActive(true);
                int diceV = PublicVars.diceVal;
                if (diceV <= 4){StartCoroutine(Death());}
                else {PublicVars.diceRollModifier = 0;}

                //other.GetComponent<PlayerMove>().Teleport(diceV);
            }
            print(PublicVars.numStrikes);
        }
    }

    IEnumerator Death(){
        yield return new WaitForSeconds(2f);
        FindObjectOfType<TransitionManager>().LoadScene("Start");
    }

}
