using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable targetedObject;

    public void SetTargetedObject(IInteractable newObject)
    {
        if (targetedObject != newObject)
            targetedObject = newObject;
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
