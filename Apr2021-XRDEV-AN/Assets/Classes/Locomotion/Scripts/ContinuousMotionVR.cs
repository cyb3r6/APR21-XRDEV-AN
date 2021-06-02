using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMotionVR : MonoBehaviour
{
    public Transform xRRig;
    public Transform director;

    private VRinput controller;

    private Vector3 forwardDirection;
    private Vector3 rightDirection;
    
    void Start()
    {
        controller = GetComponent<VRinput>();
    }

    
    void Update()
    {
        forwardDirection = director.forward;
        forwardDirection.y = 0f;
        forwardDirection.Normalize();

        rightDirection = director.right;
        rightDirection.y = 0f;
        rightDirection.Normalize();

        xRRig.position += forwardDirection * controller.thumbstick.y * Time.deltaTime;
        xRRig.position += rightDirection * controller.thumbstick.x * Time.deltaTime;
    }
}
