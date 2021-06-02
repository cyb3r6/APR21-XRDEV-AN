using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform xRRig;

    private VRinput controller;
    private LineRenderer line;
    private Vector3 hitPosition;
    private bool shouldTeleport;
    
    void Start()
    {
        controller = GetComponent<VRinput>();
        line = GetComponent<LineRenderer>();
        controller.OnThumbstickUpdated.AddListener(RaycastTeleport);
        controller.OnThumbstickUp.AddListener(Teleport);
    }

    
    
    public void RaycastTeleport()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            hitPosition = hit.point;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hitPosition);


        }
    }

    public void Teleport()
    {

    }
}
