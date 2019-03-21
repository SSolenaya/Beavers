using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {

    public class BeaverController : MonoBehaviour {

        public Beaver prefabBeaver;
        private List <Beaver> allBeavers = new List<Beaver>(15);

        public static BeaverController inst;

        public void SetBeaversOnField () {

            for(int i = 0; i < GP.beaversInPortion; i++) {

                Hole emptyHole = MapController.inst.SetEmptyHole();
                if(emptyHole != null) {
                    var beaver = Instantiate(prefabBeaver);
                    beaver.transform.SetParent(emptyHole.PositionOfHole());
                    beaver.transform.localPosition = Vector3.zero;
                    beaver.transform.localScale = Vector3.one;
                    beaver.gameObject.SetActive(true);
                    beaver.Setup(emptyHole);
                    allBeavers.Add(beaver);
                } else {
                    Debug.Log("Нет пустой ячейки");
                }

            }

        }

        public void CleaningField() {
            foreach (var hb in allBeavers) {
                if (hb.isHidden) {
                    Destroy(hb);
                    allBeavers.Remove(hb);
                }
            }
        }

        public IEnumerator IEnumRepeatPortion() {
            while (MainLogic.inst.state) {
                yield return new WaitForSeconds(GP.timeBetweenBeaversPortions);
                SetBeaversOnField();
                yield return null;
            }
            
        }

        public void StartGenerationOfBeavers() {
            StopAllCoroutines();
            CleaningField();
            StartCoroutine(IEnumRepeatPortion());
        }

        void Start() {

        }


        void Awake() {
            inst = this;
        }
    }
}