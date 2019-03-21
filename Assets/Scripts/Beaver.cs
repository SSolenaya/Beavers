using System.Collections;
using Assets.Scripts;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Beaver: MonoBehaviour, IPointerClickHandler
{

    public RectTransform pic;
   // public Coroutine coroMove;
    public bool statusOfBeaver;
    public bool isHidden = false;
    public Image img;
    public Sprite white;
    public Sprite red;
    [HideInInspector]public Hole myHole;

  

    void Awake () {
        
       // StopAllCoroutines();
    }

    public void StatusOfBeaver () {
        var temp = Random.value;
        statusOfBeaver = temp > 0.5;
        img.sprite = statusOfBeaver ? red : white;
        
    }
    
    public void Setup(Hole h) {
        myHole = h;
        StatusOfBeaver();
        StartCoroutine(IEnumLifeOfBeaver());
    }

   
    public IEnumerator IEnumLifeOfBeaver () {
        yield return StartCoroutine(IEnumMoveBeaver (0));
        yield return new WaitForSeconds(GP.delayBeaverOnField);
        yield return StartCoroutine(IEnumMoveBeaver(-104));
        myHole.isEmpty = true;
        isHidden = true;

    }

    public IEnumerator IEnumMoveBeaver(float finalY) {
        float startY = pic.localPosition.y;
        float currentY;
        float currentTime = 0;
        float fullTime = 3f;

        
        while(currentTime < fullTime) {
            var temp = currentTime / fullTime;
            currentY = Mathf.Lerp(startY, finalY, temp);
            pic.localPosition = new Vector3(0, currentY, 0);
            currentTime += Time.deltaTime;
            yield return null;
        }

        pic.localPosition = new Vector3(0, finalY, 0);
    }

    
    public void OnPointerClick (PointerEventData pointerEventData) {

        StopCoroutine(IEnumLifeOfBeaver());
        StartCoroutine( IEnumMoveBeaver(-104f));
        myHole.isEmpty = true;
        isHidden = true;

        if (statusOfBeaver) {
            PlayerController.inst.CountPoints();
        }
        else {
            PlayerController.inst.CountLives();
        }

    }




}
