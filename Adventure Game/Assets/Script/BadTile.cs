using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadTile : MonoBehaviour
{
    MeshRenderer _meshRender;
    public Material unlitm;
    public Material litm;
    public Transform startofroom;
    public GameObject[] tiles;
    public GameObject mainCam;
    public GameObject roomCam;
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
            //light up red, wait a second, teleport back
            _meshRender.material = litm;
            StartCoroutine(waiting(other));
            //teleport
            //other.GetComponent<NavMeshAgent>().Warp(startofroom.position);
        }
    }

    IEnumerator waiting(Collider other){
        yield return new WaitForSeconds(1f);
        roomCam.SetActive(true);
        mainCam.SetActive(false);
        foreach (GameObject h in tiles){
            h.GetComponent<GoodTile>().TurnOff();
        }
        _meshRender.material = unlitm;
        other.GetComponent<NavMeshAgent>().Warp(startofroom.position);
        print("teleported, no lights yet");
        yield return new WaitForSeconds(1f);
        //have each tile light up and turn off
        foreach (GameObject g in tiles){
            g.GetComponent<GoodTile>().FlashCorrect();
            yield return new WaitForSeconds(0.5f);
        }
        print("turned on, now wait to turn off");
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject h in tiles){
            h.GetComponent<GoodTile>().TurnOff();
        }
        //swap camera back
        mainCam.SetActive(true);
        roomCam.SetActive(false);
    }
}
