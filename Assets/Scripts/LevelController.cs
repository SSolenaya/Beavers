using System.Collections;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class LevelController: MonoBehaviour {


        public static LevelController inst;

        void Awake () {

            inst = this;
        }


        public static void EasyLevel () {
            GP.timeBetweenPortions = 4;
            GP.entitiesInPortion = 1;
            GP.delayEntityOnField = 4;
            GP.complicationGameplayWithTime = 1.25f;
            GP.timeToChangeN = 120;

            GP.pointsForBeaver = 100;
            GP.coefSeries = 1;
            GP.deltaCoefSeries = 0.25f;
        }

        public static void MediumLevel () {
            GP.timeBetweenPortions = 3;
            GP.entitiesInPortion = 1;
            GP.delayEntityOnField = 3;
            GP.complicationGameplayWithTime = 1.5f;
            GP.timeToChangeN = 90;

            GP.pointsForBeaver = 200;
            GP.coefSeries = 1.25f;
            GP.deltaCoefSeries = 0.5f;
        }

        public static void HardLevel () {
            GP.timeBetweenPortions = 2;
            GP.entitiesInPortion = 2;
            GP.delayEntityOnField = 2;
            GP.complicationGameplayWithTime = 1.75f;
            GP.timeToChangeN = 60;

            GP.pointsForBeaver = 300;
            GP.coefSeries = 1.5f;
            GP.deltaCoefSeries = 0.75f;
        }

        public IEnumerator BeaversQuantity () {

            while(PlayerController.inst.alive) {
                yield return new WaitForSeconds(GP.timeToChangeN);
                GP.entitiesInPortion += 1;

            }
        }

        public IEnumerator IEnumGameMode () {

            while(PlayerController.inst.alive) {
                yield return new WaitForSeconds(GP.timeToChangeKM);
                GP.timeBetweenPortions /= GP.complicationGameplayWithTime;
                GP.delayEntityOnField /= GP.complicationGameplayWithTime;
            }
        }

        public void ComplicatingGame () {
            StartCoroutine(BeaversQuantity());
            StartCoroutine(IEnumGameMode());
        }

        public static void Reset () {
            if(inst != null) {
                inst.StopAllCoroutines();
            }

        }

        void Start () {
            ComplicatingGame();
        }

    }

}