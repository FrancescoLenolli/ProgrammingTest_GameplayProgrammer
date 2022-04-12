using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework.StateMachine;

public class UIState_Main : UIState
{
    protected UIRoot_Main root;

    public override void PrepareState(UIStateMachine owner)
    {
        base.PrepareState(owner);
        if (!root)
            root = (UIRoot_Main)owner.Root;
    }
}
