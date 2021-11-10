using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PublicVars.numTilesMand >= 4){
            //apply force
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("stop")){
            transform.Translate(new Vector3(0,0,0));
        }
    }
}
