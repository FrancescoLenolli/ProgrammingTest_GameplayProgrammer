using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject source;

    public void Interact1()
    {
        source.SetActive(true);
    }

    public void Interact2()
    {
        source.SetActive(false);
    }
}
