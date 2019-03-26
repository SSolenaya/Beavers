using System.Collections;
using Assets.Scripts;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Beaver: MonoBehaviour, IPointerClickHandler {

    public RectTransform pic;
    public Coroutine coroLife;
    public bool statusOfBeaver;
    //public bool isHidden = false;
    public Image img;
    public Sprite white;
    public Sprite red;
    [HideInInspector] public Hole myHole;




    void Awake () {

        // StopAllCoroutines();
    }

    public void StatusOfBeaver () {
        var temp = Random.value;
        statusOfBeaver = temp > 0.5;
        img.sprite = statusOfBeaver ? red : white;

    }

    public void Setup (Hole h) {
        myHole = h;
        myHole.isEmpty = false;
        StatusOfBeaver();
        StopCoroLife();
        coroLife = StartCoroutine(IEnumLifeOfBeaver());
    }

    public void DeleteHiddenBeaver () {
        myHole.isEmpty = true;
        
        Destroy(gameObject);
    }

    public void PointsForSkipBeaver() {
        if(statusOfBeaver) {
            PlayerController.inst.CountLives();
        } else {
            PlayerController.inst.CountPoints();
        }
    }


    public IEnumerator IEnumHideBeaver () {
        yield return StartCoroutine(IEnumMoveBeaver(-104));
        DeleteHiddenBeaver();

    }

    public IEnumerator IEnumLifeOfBeaver () {
        yield return StartCoroutine(IEnumMoveBeaver(-10));
        yield return new WaitForSeconds(GP.delayBeaverOnField);
        yield return StartCoroutine(IEnumMoveBeaver(-104));
        DeleteHiddenBeaver();
        PointsForSkipBeaver();

    }

    public IEnumerator IEnumMoveBeaver (float finalY) {
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


    public void OnPointerClick (PointerEventData pointerEventData) {
        StopCoroLife();
        coroLife = StartCoroutine(IEnumHideBeaver());

        if(statusOfBeaver) {
            PlayerController.inst.CountPoints();
        } else {
            PlayerController.inst.CountLives();
        }

    }



    public void StopCoroLife () {
        StopAllCoroutines();
        /*if(coroLife != null) {
            StopCoroutine(coroLife);
        }
        coroLife = null;*/
    }

    /*  public void Reset() {

      }*/


    public void OnDestroy () {
        StopAllCoroutines();
    }


    public void Start () {

    }

}
