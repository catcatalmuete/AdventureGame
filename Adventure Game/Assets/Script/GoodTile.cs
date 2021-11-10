using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTile : MonoBehaviour
{
    MeshRenderer _meshRender;
    public Material lit;
    public Material unlit;
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
            FlashCorrect();
        }
    }

    public void FlashCorrect(){
        //
        _meshRender.material = lit;
    }

    public void TurnOff(){
        //
        _meshRender.material = unlit;
    }
}
