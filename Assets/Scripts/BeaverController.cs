using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BeaverController : MonoBehaviour {

    public GameObject prefab;

    public static BeaverController inst;

    public void SetBeaversOnField () {

        for (int i = 0; i < GP.beaversInPortion; i++) {

            var emptyHole = MapController.inst.SetEmptyHole();
            if (emptyHole != null) {
                var beaver = Instantiate(prefab);
                beaver.transform.SetParent(emptyHole.PositionOfHole());
                beaver.transform.localPosition = Vector3.zero;
                beaver.transform.localScale = Vector3.one;
                beaver.gameObject.SetActive(true);
                Beaver.inst.Setup(emptyHole);
            }
            else Debug.Log("Нет пустой ячейки");

        }
            
    }
    void Start()
    {
        
    }

    
    void Awake() {
        inst = this;
    }
}
