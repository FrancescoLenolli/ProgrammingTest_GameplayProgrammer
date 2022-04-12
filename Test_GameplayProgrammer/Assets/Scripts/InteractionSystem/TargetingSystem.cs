using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Backbone of the InteractionSystem.
 * Find a interactable target using a TargetingMethod (raycast is the most common one
 * but there are others methods you could use) and display the valid target using
 * a TargetingBehaviour (highlight it with a shader, increase its size or make it rotate, etc...).
 */
public class TargetingSystem : MonoBehaviour
{
    public bool enableTargeting = false;

    private TargetingBehaviour targetingBehaviour;
    private TargetingMethod targetingMethod;
    private Transform target;
    private Action<Interactable> onTargeting;

    public Action<Interactable> OnTargeting { get => onTargeting; set => onTargeting = value; }

    private void Awake()
    {
        targetingBehaviour = GetComponent<TargetingBehaviour>();
        targetingMethod = GetComponent<TargetingMethod>();

        if (!targetingBehaviour)
            Debug.LogError($"Targeting Behaviour missing in {gameObject.name}!");
        if (!targetingMethod)
            Debug.LogError($"Targeting Method missing in {gameObject.name}!");
    }

    private void Update()
    {
        FindTarget();
    }

    private void FindTarget()
    {
        if (!targetingBehaviour || !targetingMethod)
            return;

        target = targetingMethod.GetTarget();

        if (targetingBehaviour.IsNewTarget(target))
        {
            onTargeting?.Invoke(targetingBehaviour.GetValidTarget(target));
        }
    }
}
