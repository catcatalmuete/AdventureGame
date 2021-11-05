using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    public Animator playerAnimator;

    public enum Color
    {
        Blue,
        Purple,
        Green,
        Orange
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

        if(playerAnimator.velocity != Vector3.zero)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else if(playerAnimator.velocity == Vector3.zero)
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    public void Teleport(int diceroll)
    {
        // recaled on 4 rooms
        if (diceroll <= 3){
            //teleport purple / bad
            //transform.position = new Vector3(-50, 1, 50);
            _navMeshAgent.Warp(rooms[(int)Color.Purple].spawnPos.position);
            print("purple");
            return;
        }
        else if(diceroll <= 6){
            //teleport green / normal
            _navMeshAgent.Warp(rooms[(int)Color.Green].spawnPos.position);
            print("green");
            return;
        }
        else if(diceroll <= 9){
            //teleport blue / initial
            //transform.position = new Vector3(-0, 1, 0);
            _navMeshAgent.Warp(rooms[(int)Color.Blue].spawnPos.position);
            print("blue");
        }
        else {
            //teleport blue / initial
            //transform.position = new Vector3(-0, 1, 0);
            _navMeshAgent.Warp(rooms[(int)Color.Orange].spawnPos.position);
            print("orange");
        }
    }
}
