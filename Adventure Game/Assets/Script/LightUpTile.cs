using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpTile : MonoBehaviour
{
    bool lit = false;
    MeshRenderer _meshRender;
    // Start is called before the first frame update
    void Start()
    {
        _meshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            //
            if (lit == false){
                lit = true;
                _meshRender.material.EnableKeyword("_EMISSION");
            }
            else{
                lit = false;
                _meshRender.material.DisableKeyword("_EMISSION");
            }
        }
    }
}
