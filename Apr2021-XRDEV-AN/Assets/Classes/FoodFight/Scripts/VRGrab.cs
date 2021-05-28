using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRinput controller;

    /// <summary>
    /// What we're going to grab
    /// </summary>
    public GrabbableObject hoveredObject;

    /// <summary>
    /// What we are grabbing
    /// </summary>
    public GrabbableObject grabbedObject;

    public float throwForce;
    
    void Start()
    {
        controller = GetComponent<VRinput>();

        controller.OnGripDown.AddListener(Grab);
        controller.OnGripUp.AddListener(Release);
    }

    private void OnDisable()
    {
        controller.OnGripDown.RemoveListener(Grab);
        controller.OnGripUp.RemoveListener(Release);
    }

    private void OnTriggerEnter(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if(grabbable != null)
        {
            hoveredObject = grabbable;
            hoveredObject.OnHoverStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if(grabbable == hoveredObject)
        {
            hoveredObject.OnHoverEnd();
            hoveredObject = null;
        }
    }


    public void Grab()
    {
        if(hoveredObject != null)
        {
            grabbedObject = hoveredObject;
            grabbedObject.OnGrab(controller);

            // adding interactions
            controller.OnTriggerDown.AddListener(grabbedObject.OnInteraction);
            controller.OnTriggerUpdated.AddListener(grabbedObject.OnUpdatingInteraction);
            controller.OnTriggerUp.AddListener(grabbedObject.OnStopInteraction);
        }
    }

    public void Release()
    {
        if(grabbedObject != null)
        {
            grabbedObject.OnRelease(controller);

            // remove interactions
            controller.OnTriggerDown.RemoveListener(grabbedObject.OnInteraction);
            controller.OnTriggerUpdated.RemoveListener(grabbedObject.OnUpdatingInteraction);
            controller.OnTriggerUp.RemoveListener(grabbedObject.OnStopInteraction);

            // throw
            grabbedObject.rigidBody.velocity = controller.velocity * throwForce;
            grabbedObject.rigidBody.angularVelocity = controller.velocity * throwForce;
            
            grabbedObject = null;
        }
    }
}
