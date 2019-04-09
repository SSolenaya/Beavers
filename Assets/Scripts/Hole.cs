using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {

    public class Hole: MonoBehaviour {

        public bool isEmpty;
        public List<Entity> entitiesInsideList = new List<Entity>();

        public Transform PositionOfHole () {
            return transform;

        }

    }
}