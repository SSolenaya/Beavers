using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour {

   // public Image heartImg;

    public IEnumerator IEnumHeartsAnimation (Vector3 finishLocalScale) {
        yield return null;
        float currentTime = 0;
        float fullTime = 1f;
        var startLocalScale = transform.localScale;

        while(currentTime < fullTime) {
            var temp = currentTime / fullTime;
            transform.localScale = Vector3.Lerp(startLocalScale, finishLocalScale, temp);
            currentTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = finishLocalScale;
     }

    public void ShowHearts() {
        StartCoroutine(IEnumHeartsAnimation(Vector3.one));
    }

    public void HideHearts () {
        StartCoroutine(IEnumHeartsAnimation(Vector3.zero));
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
