using System.Collections;
using System.Collections.Generic;
using UIFramework.StateMachine;
using UnityEngine;

public class UIState_Main_HUD : UIState_Main
{
    private UIView_Main_HUD view;

    public override void PrepareState(UIStateMachine owner)
    {
        base.PrepareState(owner);
        view = root.viewHUD;
        root.player.PlayerInteraction.onTargetedObject += view.ShowContextMenu;
    }

    public override void ShowState()
    {
        view.ShowView();
    }

    public override void HideState()
    {
        view.HideView();
    }
}
