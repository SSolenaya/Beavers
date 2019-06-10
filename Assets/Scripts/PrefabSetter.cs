using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PrefabSetter : MonoBehaviour {
    public static PrefabSetter inst;

    public Entity prefabBeaver;
    public Entity prefabDog;

    public Entity GetBeaver() {
        return prefabBeaver;
    }
    public Entity GetDog () {
        return prefabDog;
    }
    void Awake() {
        inst = this;
    }

  }
