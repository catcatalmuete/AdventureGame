using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalLightUp : MonoBehaviour
{
    bool lit = false;
    MeshRenderer _meshRender;
    public Material unlitm;
    public Material litm;
    // Start is called before the first frame update
    void Start()
    {
        _meshRender = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TurnOff(){
        lit = false;
        _meshRender.material = unlitm;
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if (PublicVars.numTilesOp >= 13){
                _meshRender.material = litm;
            }
            else{
                if (lit == false){
                    PublicVars.numTilesOp++;
                    lit = true;
                    _meshRender.material = litm;
                }
                else{
                    PublicVars.numTilesOp--;
                    lit = false;
                    _meshRender.material = unlitm;
                }
            }
        }
    }
}
