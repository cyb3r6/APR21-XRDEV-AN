using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform button;
    public Transform down;
    public AudioSource audioSource;
    // the up position of the button
    private Vector3 originalPosition;
    
    void Awake()
    {
        originalPosition = button.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = down.position;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.position = originalPosition;
        }
    }

}
