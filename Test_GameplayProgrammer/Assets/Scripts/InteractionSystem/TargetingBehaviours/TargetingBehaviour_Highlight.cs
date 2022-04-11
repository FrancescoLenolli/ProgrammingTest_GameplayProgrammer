using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingBehaviour_Highlight : TargetingBehaviour
{
    [SerializeField] private Material highlightMaterial;
    private MeshRenderer targetRenderer;
    private Material defaultMaterial;

    protected override void FocusOn()
    {
        targetRenderer = target.GetComponent<MeshRenderer>();
        if (!targetRenderer)
            targetRenderer = target.GetComponentInChildren<MeshRenderer>();

        defaultMaterial = targetRenderer.material;
        targetRenderer.material = highlightMaterial;
    }

    protected override void FocusOff()
    {
        if (targetRenderer)
        {
            targetRenderer.material = defaultMaterial;
            targetRenderer = null;
        }
    }
}
