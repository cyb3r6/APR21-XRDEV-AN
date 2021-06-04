using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapTurn : MonoBehaviour
{
    public Transform xRRig;
    public int angle;

    private VRinput controller;

    
    void Start()
    {
        controller = GetComponent<VRinput>();
    }

    
    void Update()
    {
        if(controller.thumbstick.x > 0.9f)
        {
            xRRig.transform.Rotate(0, angle, 0);
        }
        if (controller.thumbstick.x < -0.9f)
        {
            xRRig.transform.Rotate(0, -angle, 0);
        }
    }
}
