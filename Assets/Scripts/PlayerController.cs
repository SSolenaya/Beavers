using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController inst;

    public bool Alive = true;

    public List<Image> lives = new List<Image>();

    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
