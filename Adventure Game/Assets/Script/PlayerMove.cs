using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;

    public enum Color
    {
        Blue,
        Purple,
        Green
    }

    public Room[] rooms;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200))
            {
                _navMeshAgent.destination = hit.point;
            }
        }
    }

    public void Teleport(int diceroll)
    {
        if (diceroll < 3)
        {
            //teleport purple
            //transform.position = new Vector3(-50, 1, 50);
            _navMeshAgent.Warp(rooms[(int)Color.Purple].spawnPos.position);
            print("purple");
            return;
        }
        else if(diceroll < 5){
            //teleport green
            _navMeshAgent.Warp(rooms[(int)Color.Green].spawnPos.position);
            print("green");
            return;
        }
        else
        {
            //teleport blue
            //transform.position = new Vector3(-0, 1, 0);
            _navMeshAgent.Warp(rooms[(int)Color.Blue].spawnPos.position);
            print("blue");
        }
    }
}