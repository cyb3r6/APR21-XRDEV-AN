using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRinput : MonoBehaviour
{
    public Hand hand = Hand.Left;

    private string gripButton;
    private string gripAxis;

    public float gripValue;

    public UnityEvent OnGripDown;
    
    void Start()
    {
        gripButton = $"{hand}GripButton";
        gripAxis = $"{hand}Grip";
    }

    
    void Update()
    {
        if (Input.GetButtonDown(gripButton))
        {
            OnGripDown?.Invoke();
        }

        gripValue = Input.GetAxis(gripAxis);
    }
}

[System.Serializable]
public enum Hand
{
    Left,
    Right
}
