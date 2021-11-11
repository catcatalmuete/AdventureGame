using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureBoard : MonoBehaviour
{
    public GameObject chestO;
    public GameObject chestI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shield")) 
        {
            StartCoroutine(OpenChest());
        }
    }

    IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1f);
        //play sound
        chestO.GetComponent<Animation>().Play("ChestAnim");
        chestI.GetComponent<Animation>().Play("ChestAnim");
        PublicVars.WOpen = true;

    }
    
}
