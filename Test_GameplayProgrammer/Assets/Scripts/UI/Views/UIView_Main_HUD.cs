using System;
using TMPro;
using UIFramework.StateMachine;
using UIFramework.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIView_Main_HUD : UIView
{
    [SerializeField] private TextMeshProUGUI labelItemName = null;
    [SerializeField] private TextMeshProUGUI labelInteraction1 = null;
    [SerializeField] private TextMeshProUGUI labelInteraction2 = null;
    [SerializeField] private CanvasGroup contextMenu = null;
    private Action onInteraction1;
    private Action onInteraction2;

    public override void ShowView()
    {
        base.ShowView();

        /*
         * If the Player open the context menu and then open the Options menu,
         * when going back the context menu is still open, and the cursor needs to be visible.
         */
        if (contextMenu.alpha > 0)
            Cursor.visible = true;
    }

    public void ShowContextMenu(Interactable item)
    {
        if (item)
        {
            UIUtils.ShowObject(contextMenu, true);
            labelItemName.text = item.name;
            labelInteraction1.text = item.interactionLabels[0];
            labelInteraction2.text = item.interactionLabels[1];
            onInteraction1 = item.Interact1;
            onInteraction2 = item.Interact2;
            return;
        }
        else
        {
            UIUtils.ShowObject(contextMenu, false);
            return;
        }
    }

    public void Interaction1()
    {
        onInteraction1?.Invoke();
    }

    public void Interaction2()
    {
        onInteraction2?.Invoke();
    }
}
