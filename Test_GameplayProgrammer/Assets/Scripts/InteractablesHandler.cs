using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Makes it easier to tweak values for all the interactable objects in the scene
 * from the Options Menu. If you want to change values for a single object
 * you could link up the Item targeted by the Player to the Options Menu instead.
 */
public class InteractablesHandler : MonoBehaviour
{
    private List<ObjectRotator> objectRotators = new List<ObjectRotator>();
    private List<ObjectScaler> objectScalers = new List<ObjectScaler>();

    private void Awake()
    {
        objectRotators = FindObjectsOfType<ObjectRotator>().ToList();
        objectScalers = FindObjectsOfType<ObjectScaler>().ToList();
    }

    public void SetAdditionalRotation(float angle)
    {
        objectRotators.ForEach(rotator => rotator.AdditionalRotation = angle);
    }

    public void SetScalePercentage(float scale)
    {
        objectScalers.ForEach(scaler => scaler.ScalePercentage = scale);
    }
}
