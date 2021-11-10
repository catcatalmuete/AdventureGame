using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOptional : MonoBehaviour
{
    public GameObject[] tiles;
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
            foreach (GameObject t in tiles){
                t.GetComponent<OptionalLightUp>().TurnOff();
                PublicVars.numTilesOp = 0;
            }
        }
    }
}
