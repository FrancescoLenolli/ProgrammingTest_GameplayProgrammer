using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : Interactable
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float maxRotation = 45f;
    private float startingRotationY;

    private void Awake()
    {
        startingRotationY = transform.rotation.eulerAngles.y;
    }

    public override void Interact1()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        float clampedRotationY = Mathf.Clamp(eulerRotation.y,
            startingRotationY - maxRotation, startingRotationY + maxRotation);
        transform.rotation = Quaternion.Euler(eulerRotation.x, clampedRotationY, eulerRotation.z);
    }

    public override void Interact2()
    {
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        float clampedRotationY = Mathf.Clamp(eulerRotation.y,
            startingRotationY - maxRotation, startingRotationY + maxRotation);
        transform.rotation = Quaternion.Euler(eulerRotation.x, clampedRotationY, eulerRotation.z);
    }
}
