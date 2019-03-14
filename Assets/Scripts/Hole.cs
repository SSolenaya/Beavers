using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour

{

    //public int posX;
    //public int posY;
    //public Vector3 posOnField;

    // public static Hole inst;

    public bool isEmpty;
   
    public Vector3 PositionOfHole()
    {
        isEmpty = false;
        return transform.position;
        
    }

    /*void Awake()
    {
        inst = this;
    }*/

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
