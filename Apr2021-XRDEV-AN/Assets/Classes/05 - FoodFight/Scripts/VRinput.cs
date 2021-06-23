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
    private string thumbstickX;
    private string thumbstickY;
    private string thumbstickButton;

    public float gripValue;
    public float triggerValue;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public Vector2 thumbstick;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    public UnityEvent OnGripDown;
    public UnityEvent OnGripUpdated;
    public UnityEvent OnGripUp;
    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUpdated;
    public UnityEvent OnTriggerUp;
    public UnityEvent OnThumbstickDown;
    public UnityEvent OnThumbstickUpdated;
    public UnityEvent OnThumbstickUp;

    void Start()
    {
        gripButton = $"{hand}GripButton";
        gripAxis = $"{hand}Grip";
        triggerButton = $"{hand}TriggerButton";
        //triggerAxis = $"{hand}TriggerAxis";
        thumbstickX = $"{hand}ThumbstickX";
        thumbstickY = $"{hand}ThumbstickY";
        thumbstickButton = $"{hand}ThumbstickButton";
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

        if (Input.GetButtonDown(thumbstickButton))
        {
            OnThumbstickDown?.Invoke();
        }

        if (Input.GetButton(thumbstickButton))
        {
            OnThumbstickUpdated?.Invoke();
        }

        if (Input.GetButtonUp(thumbstickButton))
        {
            OnThumbstickUp?.Invoke();
        }

        gripValue = Input.GetAxis(gripAxis);
        //triggerValue = Input.GetAxis(triggerAxis);
        thumbstick = new Vector2(Input.GetAxis(thumbstickX), Input.GetAxis(thumbstickY));

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
