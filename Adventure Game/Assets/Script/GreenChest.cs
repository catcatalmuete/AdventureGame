using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenChest : MonoBehaviour
{
    Animation ani;
    // Start is called before the first frame update
    void Start()
    {
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
            int diceV = PublicVars.diceVal;
            other.GetComponent<PlayerMove>().Teleport(diceV);
        }
    }

}
