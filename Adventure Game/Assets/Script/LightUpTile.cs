using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpTile : MonoBehaviour
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

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if (PublicVars.numTilesMand >= 4){
                _meshRender.material = litm;
            }
            else{
                if (lit == false){
                    PublicVars.numTilesMand++;
                    lit = true;
                    _meshRender.material = litm;
                }
                else{
                    PublicVars.numTilesMand--;
                    lit = false;
                    _meshRender.material = unlitm;
                }
            }
        }
    }
}
