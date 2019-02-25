using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beaver_Controller : MonoBehaviour
{

    public Sprite red_beaver;
    public Sprite white_beaver;

    private bool status_of_beaver = true;

    public bool Status_of_Beaver()
    {
        var temp = Random.value;
        status_of_beaver = temp > ? true : false;
        return status_of_beaver;
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
