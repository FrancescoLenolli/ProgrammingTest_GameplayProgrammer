using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Define how to get a valid Interactable target.
 * There are several ways to search for a target inside a scene,
 * with Raycasting being the most used.
 */
public abstract class TargetingMethod : MonoBehaviour
{
    public abstract Transform GetTarget();
}
