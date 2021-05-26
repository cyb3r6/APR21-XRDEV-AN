using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRinput : MonoBehaviour
{
    public Hand hand = Hand.Left;

    private string gripButton;
    private string gripAxis;
    private string triggerButton;
    private string triggerAxis;

    public float gripValue;
    public float triggerValue;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    public UnityEvent OnGripDown;
    public UnityEvent OnGripUpdated;
    public UnityEvent OnGripUp;
    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUpdated;
    public UnityEvent OnTriggerUp;

    void Start()
    {
        gripButton = $"{hand}GripButton";
        gripAxis = $"{hand}Grip";
        triggerButton = $"{hand}TriggerButton";
    }

    
    void Update()
    {
        if (Input.GetButtonDown(gripButton))
        {
            OnGripDown?.Invoke();
        }

        if (Input.GetButton(gripButton))
        {
            OnGripUpdated?.Invoke();
        }

        if (Input.GetButtonUp(gripButton))
        {
            OnGripUp?.Invoke();
        }
        if (Input.GetButtonDown(triggerButton))
        {
            OnTriggerDown?.Invoke();
        }

        if (Input.GetButton(triggerButton))
        {
            OnTriggerUpdated?.Invoke();
        }

        if (Input.GetButtonUp(triggerButton))
        {
            OnTriggerUp?.Invoke();
        }

        gripValue = Input.GetAxis(gripAxis);

        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;
    }
}

[System.Serializable]
public enum Hand
{
    Left,
    Right
}
