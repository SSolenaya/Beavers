using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

    public static MapController inst;

    public void Awake() {
        inst = this;
    }
    
    public List<Hole> map = new List<Hole>();



    public Hole SetEmptyHole()
    {
        bool exit = false;
        while (!exit)
        {
            int temp = Random.Range(0, 15);
            if (map[temp].isEmpty)
            {
                exit = true;
                map[temp].isEmpty = false;
                return map[temp];
            }
        }

        return null;
    }

}
