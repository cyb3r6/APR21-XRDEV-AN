using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Color hoverColor;
    public Color nonHoverColor;

    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
    }
    public void OnHoverStart()
    {
        objectMaterial.color = hoverColor;
    }

    public void OnHoverEnd()
    {
        objectMaterial.color = nonHoverColor;
    }
}
