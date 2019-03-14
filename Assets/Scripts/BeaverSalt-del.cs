using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class BeaverSalt : MonoBehaviour
    {
        public RectTransform img;
        public Coroutine coroMove;
        public bool pause;

        public void Start()
        {

        }

        public void StopCoroMove()
        {
            if (coroMove != null)
            {
                StopCoroutine(coroMove);
            }

            coroMove = null;
        }

        [EasyButtons.Button]
        public void ShowBeaver()
        {
            StopCoroMove();
            coroMove = StartCoroutine(IEnumMove(0));
        }

        [EasyButtons.Button]
        public void HideBeaver()
        {
            StopCoroMove();
            coroMove = StartCoroutine(IEnumMove(-100));
        }


        public IEnumerator IEnumMove(float finalY)
        {
            float currentTime = 0;
            float time = 5;
            float startPosY = img.localPosition.y;
            float currentY;
            while (currentTime < time)
            {
                yield return null;
                if (pause)
                {
                    continue;
                }
                var t = currentTime / time;
                currentY = Mathf.Lerp(startPosY, finalY, t);

                img.localPosition = new Vector3(0,currentY,0);
                Debug.Log(Time.deltaTime);
                currentTime += Time.deltaTime;

                
            }
            img.localPosition = new Vector3(0, finalY, 0);
        }

    }
}