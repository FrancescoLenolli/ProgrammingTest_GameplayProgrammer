using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework.Utilities
{
    public static class UIUtils
    {
        public static void ShowObject(CanvasGroup canvasGroup, bool isVisible)
        {
            canvasGroup.alpha = isVisible ? 1 : 0;
            canvasGroup.blocksRaycasts = isVisible;
            canvasGroup.interactable = isVisible;
        }

        public static Vector2 IncreaseContainerHeight(Transform container, Transform additionalElement, float additionalSpace = 0)
        {
            RectTransform additionalElementRect = additionalElement.GetComponent<RectTransform>();
            RectTransform containerRect = container.GetComponent<RectTransform>();

            Vector2 containerUpdatedSize = new Vector2(containerRect.sizeDelta.x, containerRect.sizeDelta.y + additionalElementRect.sizeDelta.y + additionalSpace);
            return containerUpdatedSize;
        }

        public static Vector2 DecreaseContainerHeight(Transform container, Transform additionalElement, float additionalSpace = 0)
        {
            RectTransform additionalElementRect = additionalElement.GetComponent<RectTransform>();
            RectTransform containerRect = container.GetComponent<RectTransform>();

            Vector2 containerUpdatedSize = new Vector2(containerRect.sizeDelta.x, containerRect.sizeDelta.y - additionalElementRect.sizeDelta.y + additionalSpace);
            return containerUpdatedSize;
        }

    }
}
