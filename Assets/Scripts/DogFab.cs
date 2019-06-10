using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class DogFab: EntityFab {
    public Entity CreatePrefab () {
        return PrefabSetter.inst.GetDog();
    }
}