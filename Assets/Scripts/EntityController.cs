
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
        public EntityFab entityFactory;

        public Coroutine coroGenEntities;
        public Entity entity;

        public void ChooseAnAnimalPrefab () {
            var temp = (Animals)Random.Range(0, 2);
            switch(temp) {
                case Animals.Abeaver:
                    entityFactory = new BeaverFab();
                    break;
                case Animals.Adog:
                    entityFactory = new DogFab();
                    break;
                default:
                    entityFactory = new DogFab();
                    break;
            }
        }

        public void SetOnField () {
            for(int i = 0; i < GP.entitiesInPortion; i++) {
                ChooseAnAnimalPrefab();
                Hole emptyHole = MapController.inst.SetEmptyHole();
                if(emptyHole != null) {
                    entity = Instantiate(entityFactory.SetPrefab());
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