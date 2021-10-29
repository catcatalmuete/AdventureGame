using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    
public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
        
    void Start() 
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }
        
    void Update() 
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
                
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) 
            {
                _navMeshAgent.destination = hit.point;
            }
        }
    }

    public void Teleport(int diceroll){
        if(diceroll < 6){
            //teleport purple
            //transform.position = new Vector3(-50, 1, 50);
            _navMeshAgent.Warp(new Vector3(-50, 1, 50));
            print("purple");
            return;
        }
        /*else if(diceroll % 2 == 0){
            //teleport green
            _navMeshAgent.Warp(new Vector3(-100, 1, -10));
            print("green");
            return;
        }*/
        else{
            //teleport blue
            //transform.position = new Vector3(-0, 1, 0);
            _navMeshAgent.Warp(new Vector3(0, 1, 0));
            print("blue");
        }
    }
}
