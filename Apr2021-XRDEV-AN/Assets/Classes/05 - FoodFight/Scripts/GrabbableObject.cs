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
        objectMaterial = GetComponentInChildren<Renderer>().material;
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


    #region Parenting method of grabbing

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

    #endregion

    #region FixedJoint method of grabbing

    public void OnGrabADV(VRinput hand)
    {
        FixedJoint fx = hand.gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = rigidBody;
    }

    public void OnReleaseADV(VRinput hand)
    {
        FixedJoint fx = hand.GetComponent<FixedJoint>();
        Destroy(fx);
    }

    #endregion
}
