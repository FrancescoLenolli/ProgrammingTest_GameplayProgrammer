using System;
using UnityEngine;

/*
 * Player component with the sole puropose of handling 
 * interactions with interactable objects. Avoid filling the Player
 * script with too much clutter and could be made more generic
 * with a bit of tweaking.
 */
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
