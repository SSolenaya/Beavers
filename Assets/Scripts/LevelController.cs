using System.Collections;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts {
    public class LevelController: MonoBehaviour {


        public static LevelController inst;

        void Awake () {
            inst = this;
            StopAllCoroutines();
        }


        public static void EasyLevel () {
            GP.timeBetweenBeaversPortions = 4;
            GP.beaversInPortion = 1;
            GP.delayBeaverOnField = 4;
            GP.complicationGameplayWithTime = 1.25f;
            GP.timeToChangeN = 120;

            GP.pointsForBeaver = 100;
            GP.coefSeries = 1;
            GP.deltaCoefSeries = 0.25f;
        }

        public static void MediumLevel () {
            GP.timeBetweenBeaversPortions = 3;
            GP.beaversInPortion = 1;
            GP.delayBeaverOnField = 3;
            GP.complicationGameplayWithTime = 1.5f;
            GP.timeToChangeN = 90;

            GP.pointsForBeaver = 200;
            GP.coefSeries = 1.25f;
            GP.deltaCoefSeries = 0.5f;
        }

        public static void HardLevel () {
            GP.timeBetweenBeaversPortions = 2;
            GP.beaversInPortion = 2;
            GP.delayBeaverOnField = 2;
            GP.complicationGameplayWithTime = 1.75f;
            GP.timeToChangeN = 60;

            GP.pointsForBeaver = 300;
            GP.coefSeries = 1.5f;
            GP.deltaCoefSeries = 0.75f;
        }

        public IEnumerator BeaversQuantity () {

            while(PlayerController.inst.alive) {
                yield return new WaitForSeconds(GP.timeToChangeN);
                GP.beaversInPortion += 1;
               
            }
        }

        public IEnumerator IEnumGameMode () {

            while(PlayerController.inst.alive) {
                yield return new WaitForSeconds(GP.timeToChangeKM);
                GP.timeBetweenBeaversPortions /= GP.complicationGameplayWithTime;
                GP.delayBeaverOnField /= GP.complicationGameplayWithTime;
            }
        }


        void Start () {
            StartCoroutine(BeaversQuantity());
            StartCoroutine(IEnumGameMode());

        }
        
    }

}