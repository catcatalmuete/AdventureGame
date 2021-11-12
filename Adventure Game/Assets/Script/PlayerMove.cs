using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;
    public Animator playerAnimator;

    public enum Color
    {
        Blue,
        Purple,
        Green,
        Orange,
        Red,
        White
    }

    public Room[] rooms;
    List<Room> roomsToFinish;
    public Room currentRoom;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        currentRoom = rooms[(int)Color.Blue];
        roomsToFinish = new List<Room>(rooms);
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

        if(_navMeshAgent.velocity != Vector3.zero)
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
        // remove current room from rooms to finish if it's finished
        if (currentRoom.complete)
        {
            roomsToFinish.Remove(currentRoom);
        }
        // if no rooms are left to finish, the player wins!
        if (roomsToFinish.Count == 0)
        {
            FindObjectOfType<TransitionManager>().LoadScene("Win");
            return;
        }
        // determine the available rooms to visit
        int roomSep = 12 / roomsToFinish.Count; // divide rolls among remaining rooms
        int roomVal = (diceroll-1) / roomSep;   // set val according to roll
        Debug.Log("roomsToFinish.Count: " + roomsToFinish.Count.ToString());
        Debug.Log("diceroll: " + diceroll.ToString());
        Debug.Log("roomSep: " + roomSep.ToString());
        Debug.Log("roomVal: " + roomVal.ToString());

        currentRoom = roomsToFinish[roomVal];
         _navMeshAgent.Warp(roomsToFinish[roomVal].spawnPos.position);
        
        //for (int i = 0; i < roomsToFinish.Count; ++i)
        //{
            //if (roomVal <= i)
            //{
                ///currentRoom = roomsToFinish[i];
                //_navMeshAgent.Warp(roomsToFinish[i].spawnPos.position);
            //}
        //}
        //// diceroll = 4;
        //// recaled on 4 rooms
        //if (diceroll <= 2){
        //    //teleport purple / bad
        //    //transform.position = new Vector3(-50, 1, 50);
        //    _navMeshAgent.Warp(rooms[(int)Color.Purple].spawnPos.position);
        //    print("purple");
        //    return;
        //}
        //else if(diceroll <= 4){
        //    //teleport green / normal
        //    _navMeshAgent.Warp(rooms[(int)Color.Green].spawnPos.position);
        //    print("green");
        //    return;
        //}
        //else if(diceroll <= 6){
        //    //teleport blue / initial
        //    //transform.position = new Vector3(-0, 1, 0);
        //    _navMeshAgent.Warp(rooms[(int)Color.Blue].spawnPos.position);
        //    print("blue");
        //}
        //else if(diceroll <= 8){
        //    //teleport orange / good
        //    //transform.position = new Vector3(-0, 1, 0);
        //    _navMeshAgent.Warp(rooms[(int)Color.Orange].spawnPos.position);
        //    print("orange");
        //}
        //else if(diceroll <= 9){
        //    //teleport orange / good
        //    //transform.position = new Vector3(-0, 1, 0);
        //    _navMeshAgent.Warp(rooms[(int)Color.Red].spawnPos.position);
        //    print("red");
        //}
        //else {
        //    //teleport orange / good
        //    //transform.position = new Vector3(-0, 1, 0);
        //    _navMeshAgent.Warp(rooms[(int)Color.White].spawnPos.position);
        //    print("white");
        //}
    }
}