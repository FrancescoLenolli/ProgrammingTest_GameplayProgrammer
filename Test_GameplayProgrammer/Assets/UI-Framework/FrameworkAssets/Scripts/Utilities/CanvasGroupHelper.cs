using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFramework.Utilities
{
    /*
     * Attach this component to a UI element to set his visibility
     * using a CanvasGroup instead of setting it active or not.
     * When dealing with UI it's better to set elements visible with
     * a CanvasGroup component.
     */
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupHelper : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        public void ChangeView(bool isVisible)
        {
            UIUtils.ShowObject(GetCanvasGroup(), isVisible);
        }

        private CanvasGroup GetCanvasGroup()
        {
            if (!canvasGroup)
                canvasGroup = GetComponent<CanvasGroup>();

            return canvasGroup;
        }

        [ContextMenu("Change Visibility")]
        private void ChangeView()
        {
            bool showView = !(GetCanvasGroup().alpha == 1);
            ChangeView(showView);
        }
    }
}