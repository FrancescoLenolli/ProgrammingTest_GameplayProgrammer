using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public List<string> interactionLabels = new List<string>() { "First Interaction", "Second Interaction" };
    public abstract void Interact1();
    public abstract void Interact2();
}
