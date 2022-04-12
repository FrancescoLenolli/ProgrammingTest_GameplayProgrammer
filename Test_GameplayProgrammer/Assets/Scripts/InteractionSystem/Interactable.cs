using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base class from which all Interactable objects derive from.
 * Could be an Interface, but generally in Unity it's easier to work
 * with parent classes.
 */
public abstract class Interactable : MonoBehaviour
{
    /*
     * Display the name of the actions the player can do when interacting with an Item.
     * Could be used to hint at specific actions (For example a secret lever that opens a locked door).
     */
    public List<string> interactionLabels = new List<string>() { "First Interaction", "Second Interaction" };
    public abstract void Interact1();
    public abstract void Interact2();
}
