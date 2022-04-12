using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : Interactable
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float additionalRotation = 45f;
    private float startingRotationY;

    public float AdditionalRotation { get => additionalRotation; set => additionalRotation = value; }

    private void Awake()
    {
        startingRotationY = transform.rotation.eulerAngles.y;
    }

    public override void Interact1()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        float clampedRotationY = Mathf.Clamp(eulerRotation.y,
            startingRotationY - additionalRotation, startingRotationY + additionalRotation);
        transform.rotation = Quaternion.Euler(eulerRotation.x, clampedRotationY, eulerRotation.z);
    }

    public override void Interact2()
    {
        transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        float clampedRotationY = Mathf.Clamp(eulerRotation.y,
            startingRotationY - additionalRotation, startingRotationY + additionalRotation);
        transform.rotation = Quaternion.Euler(eulerRotation.x, clampedRotationY, eulerRotation.z);
    }
}
