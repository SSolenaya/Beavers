using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public List<Hole> map = new List<Hole>();



    public Vector3 SetPosToBeaver()
    {
        bool exit = false;
        while (!exit)
        {
            int temp = Random.Range(0, 15);
            if (map[temp].isEmpty)
            {
                return map[temp].PositionOfHole();
                exit = true;//salt7 - это никогда не выполнится
            }
        }

        return Vector3.zero;
    }




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
