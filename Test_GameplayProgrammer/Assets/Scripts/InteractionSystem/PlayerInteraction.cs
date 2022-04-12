using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Action<Interactable> onTargetedObject;
    private Interactable targetedObject;

    public void SetTargetedObject(Interactable newObject)
    {
        if (targetedObject != newObject)
            targetedObject = newObject;
    }

    public bool SelectTarget()
    {
        if (targetedObject)
        {
            onTargetedObject?.Invoke(targetedObject);
            return true;
        }
        return false;
    }

    public void DeselectTarget()
    {
        targetedObject = null;
        onTargetedObject?.Invoke(targetedObject);
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
