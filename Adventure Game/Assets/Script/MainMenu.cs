using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    TransitionManager _transitionManager;
    // Start is called before the first frame update
    void Start()
    {
        _transitionManager = FindObjectOfType<TransitionManager>();
    }

    public void Update(){
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        _transitionManager.LoadScene("Main_Demo");
    }

}