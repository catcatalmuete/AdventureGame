using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenChest : MonoBehaviour
{
    Animation ani;
    //public GameObject greenUI;
    // Start is called before the first frame update
    void Start()
    {
        //greenUI.SetActive(false);
        ani = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            ani.Play("ChestAnim");
            other.GetComponent<DiceRoll>().Roll();
            //greenUI.SetActive(true);
            int diceV = PublicVars.diceVal;
            other.GetComponent<PlayerMove>().Teleport(diceV);
        }
    }

}
