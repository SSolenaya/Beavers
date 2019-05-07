
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    enum Animals {
        Abeaver,
        Adog
    }


    public class EntityController : MonoBehaviour {
      
        public List<Entity> allEntetiesOnSession = new List<Entity>();

        public static EntityController inst;
        public Beaver prefabBeaver;
        public Dog prefabDog;

        public Coroutine coroGenEntities;
        public Entity entity;

        public Entity ChooseAnAnimalPrefab () {
            var temp = (Animals)Random.Range(0, 2);
            switch(temp) {
                case Animals.Abeaver:
                    return prefabBeaver;
                case Animals.Adog:
                    return prefabDog;
                default:
                    return prefabDog;
            }
        }

        public void SetOnField () {
            for(int i = 0; i < GP.entitiesInPortion; i++) {

                Hole emptyHole = MapController.inst.SetEmptyHole();
                if(emptyHole != null) {
                    var tempEntity = ChooseAnAnimalPrefab();
                    entity = Instantiate(tempEntity);
                    entity.transform.SetParent(emptyHole.PositionOfHole());
                    entity.transform.localPosition = Vector3.zero;
                    entity.transform.localScale = Vector3.one;
                    entity.gameObject.SetActive(true);
                    entity.Setup(emptyHole);
                    allEntetiesOnSession.Add(entity);

                } else {
                    Debug.Log("Нет пустой ячейки");
                }

            }

        }

        public void CleaningField() {
            foreach (var animal in allEntetiesOnSession) {
                if (animal != null) {
                    Destroy(animal.gameObject);
                }
            }
            }

        public IEnumerator IEnumRepeatPortion () {
            while(MainLogic.inst.state) {
                SetOnField();
                yield return new WaitForSeconds(GP.timeBetweenPortions);

            }

        }

        public void StartGenerationOfBeavers() {
            Reset();
            coroGenEntities = StartCoroutine(IEnumRepeatPortion());
        }

        public void StopGen () {
            if(coroGenEntities != null) {
                StopCoroutine(coroGenEntities);
            }
            coroGenEntities = null;
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