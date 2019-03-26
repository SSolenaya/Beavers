using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {

    public class MapController : MonoBehaviour {

        public static MapController inst;

        public void Awake() {
            inst = this;
        }

        public List<Hole> map = new List<Hole>();
       [SerializeField] private List<Hole> emptyOnes = new List<Hole>();

        public Hole SetEmptyHole() {
            emptyOnes.Clear();
            foreach (var m in map) {
                if (m.isEmpty) {
                    emptyOnes.Add(m);
                }
            }
            int temp = Random.Range(0, emptyOnes.Count);
            return emptyOnes.Count == 0 ? null : emptyOnes[temp];
        }
    }
}