using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAnimator : MonoBehaviour
{
    private VRinput controller;
    private Animator handAnimator;

    void Start()
    {
        controller = GetComponent<VRinput>();
        handAnimator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        
    }
}
