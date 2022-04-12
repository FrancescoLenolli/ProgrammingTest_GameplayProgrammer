using System.Collections;
using System.Collections.Generic;
using UIFramework.StateMachine;
using UnityEngine;

public class UIState_Main_Options : UIState_Main
{
    private UIView_Main_Options view;

    public override void PrepareState(UIStateMachine owner)
    {
        base.PrepareState(owner);
        view = root.viewOptions;
        view.onChangeMovementSpeed += (value) => root.player.MovementSpeed = value;
        view.onChangeRotationSpeed += (value) => root.player.RotationSpeed = value;
        view.onChangeRotationAngle += root.interactablesHandler.SetAdditionalRotation;
        view.onChangeScalePercentage += root.interactablesHandler.SetScalePercentage;
        root.player.onOpenOptions += OpenOptions;
        view.onCloseOptions += CloseOptions;
        view.Init();
    }

    public override void ShowState()
    {
        view.ShowView();
    }

    public override void HideState()
    {
        view.HideView();
    }

    private void OpenOptions()
    {
        Cursor.visible = true;
        root.player.PauseGame(true);
        owner.ChangeState(GetType());
    }

    private void CloseOptions()
    {
        Cursor.visible = false;
        root.player.PauseGame(false);
        owner.BackToLastState();
    }
}
