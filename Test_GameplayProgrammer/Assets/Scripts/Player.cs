using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public void OnMove(InputValue value)
    {
        Vector2 movementValues = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        // mouse returns values higher than 1 and -1.
        Vector2 rotationValue = value.Get<Vector2>();
    }

    public void OnItemInteraction1(InputValue value)
    {
        Debug.Log("Interaction1");
    }

    private void OnItemInteraction2(InputValue value)
    {
        Debug.Log("Interaction2");
    }
}
