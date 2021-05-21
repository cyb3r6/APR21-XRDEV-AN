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
    
    void Start()
    {
        controller = GetComponent<VRinput>();

        controller.OnGripDown.AddListener(Grab);
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
        Debug.Log("Grab!");
    }
}
