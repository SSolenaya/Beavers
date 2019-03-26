using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {

    public class BeaverController : MonoBehaviour {

        public Beaver prefabBeaver;
        [SerializeField]private List <Beaver> allBeavers = new List<Beaver>(15);

        public static BeaverController inst;

        public Coroutine coroGenBeavers;

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
                if (hb != null) {
                    Destroy(hb.gameObject);
                }
            }
            allBeavers.Clear();
        }

        public IEnumerator IEnumRepeatPortion () {
            while(MainLogic.inst.state) {
                SetBeaversOnField();
                yield return new WaitForSeconds(GP.timeBetweenBeaversPortions);

            }

        }

        public void StartGenerationOfBeavers() {
            Reset();
            coroGenBeavers = StartCoroutine(IEnumRepeatPortion());
        }

        public void StopGen () {
            if(coroGenBeavers != null) {
                StopCoroutine(coroGenBeavers);
            }
            coroGenBeavers = null;
        }



        public void Reset () {
            StopGen();
            CleaningField();
        }

        void Awake() {
            inst = this;
        }

    }
}