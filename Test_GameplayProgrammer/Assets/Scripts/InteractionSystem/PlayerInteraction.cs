using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Action<Interactable> onTargetedObject;
    private Interactable targetedObject;

    public void SetTargetedObject(Interactable newObject)
    {
        if (targetedObject != newObject)
        {
            targetedObject = newObject;
            onTargetedObject?.Invoke(targetedObject);
        }
    }

    public void Interact1()
    {
        if (targetedObject != null)
            targetedObject.Interact1();
    }

    public void Interact2()
    {
        if (targetedObject != null)
            targetedObject.Interact2();
    }
}
