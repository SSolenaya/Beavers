using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts {

   

    public abstract class Entity: MonoBehaviour, IPointerClickHandler {

        public RectTransform pic;
        public Coroutine coroLife;
        public bool status;
        public bool isClicked;
        public Image img;
        public Hole myHole;


      public void DeleteHiddenEntity () {
            myHole.isEmpty = true;
            Destroy(gameObject);
          OnDestroy();
        }

        public IEnumerator IEnumHideEntity () {
            yield return StartCoroutine(IEnumMoveEntity(-104));
            DeleteHiddenEntity();
        }

        public IEnumerator IEnumLifeOfEntity () {
            yield return StartCoroutine(IEnumMoveEntity(-10));
            yield return new WaitForSeconds(GP.delayEntityOnField);
            yield return StartCoroutine(IEnumMoveEntity(-104));
            DeleteHiddenEntity();
            CountPointsOrLivesForSkip();
        }

        public IEnumerator IEnumMoveEntity (float finalY) {
            float startY = pic.localPosition.y;
            float currentY;
            float currentTime = 0;
            float fullTime = 0.5f;

            while(currentTime < fullTime) {
                var temp = currentTime / fullTime;
                currentY = Mathf.Lerp(startY, finalY, temp);
                pic.localPosition = new Vector3(0, currentY, 0);
                currentTime += Time.deltaTime;
                // Debug.Log(finalY + " " + pic.localPosition);
                yield return null;
            }
            pic.localPosition = new Vector3(0, finalY, 0);
        }

        public void Setup (Hole h) {
            myHole = h;
            myHole.isEmpty = false;
            StopCoroLife();
            transform.SetParent(h.PositionOfHole());
            gameObject.SetActive(true);
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
            coroLife = StartCoroutine(IEnumLifeOfEntity());
        }

        public abstract void StatusOfEntity();
    

        public abstract void PlaySoundOnClick();
        public abstract void CountPointsOrLivesForClick ();
        public abstract void CountPointsOrLivesForSkip ();
      
        public void StopCoroLife () {
            StopAllCoroutines();
          }

        public void OnDestroy () {
            StopAllCoroutines();
        }

        public void OnPointerClick (PointerEventData pointerEventData) {
            PlaySoundOnClick();
            StopCoroLife();
            coroLife = StartCoroutine(IEnumHideEntity());
            if(!isClicked) {
                CountPointsOrLivesForClick();
            }
            isClicked = true;
        }
        }
}