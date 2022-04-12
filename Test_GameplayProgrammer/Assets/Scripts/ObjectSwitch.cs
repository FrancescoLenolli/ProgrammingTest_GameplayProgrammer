using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : Interactable
{
    [SerializeField] private GameObject source;

    public override void Interact1()
    {
        source.SetActive(true);
    }

    public override void Interact2()
    {
        source.SetActive(false);
    }
}
