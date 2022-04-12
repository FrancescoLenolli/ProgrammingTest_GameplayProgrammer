using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UIFramework.StateMachine;
using UIFramework.Utilities;

public class UIView_Main_HUD : UIView
{
    [SerializeField] private TextMeshProUGUI labelItemName = null;
    [SerializeField] private TextMeshProUGUI labelInteraction1 = null;
    [SerializeField] private TextMeshProUGUI labelInteraction2 = null;
    [SerializeField] private CanvasGroup contextMenu = null;

    public void ShowContextMenu(Interactable item)
    {
        if (item)
        {
            UIUtils.ShowObject(contextMenu, true);
            labelItemName.text = item.name;
            labelInteraction1.text = item.interactionLabels[0];
            labelInteraction2.text = item.interactionLabels[1];
            return;
        }
        else
        {
            UIUtils.ShowObject(contextMenu, false);
            return;
        }
    }
}
