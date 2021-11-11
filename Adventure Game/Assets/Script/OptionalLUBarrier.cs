using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalLUBarrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PublicVars.numTilesOp >= 13){
            transform.Translate(Vector3.down * Time.deltaTime, Space.World);
        }
    }
}
