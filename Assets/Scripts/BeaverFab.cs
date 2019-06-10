using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BeaverFab : EntityFab
{
    public Entity CreatePrefab() {
        return PrefabSetter.inst.GetBeaver();
    }
}
