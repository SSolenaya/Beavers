using UnityEngine;

namespace Assets.Scripts
{
    public class Cell : MonoBehaviour
    {
        public RectTransform parentForBears;

        public RectTransform GetParent()
        {
            return parentForBears;
        }
    }
}