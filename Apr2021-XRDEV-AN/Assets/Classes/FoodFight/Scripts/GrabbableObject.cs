using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public Color hoverColor;
    public Color nonHoverColor;
    public Rigidbody rigidBody;
    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<Renderer>().material;
        rigidBody = GetComponent<Rigidbody>();
    }

    public virtual void OnInteraction()
    {

    }

    public virtual void OnUpdatingInteraction()
    {

    }

    public virtual void OnStopInteraction()
    {

    }

    public void OnHoverStart()
    {
        objectMaterial.color = hoverColor;
    }

    public void OnHoverEnd()
    {
        objectMaterial.color = nonHoverColor;
    }

    public void OnGrab(VRinput hand)
    {
        Debug.Log("Grab!");
        transform.SetParent(hand.transform);
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnRelease(VRinput hand)
    {
        Debug.Log("Release!");
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;


    }
}
