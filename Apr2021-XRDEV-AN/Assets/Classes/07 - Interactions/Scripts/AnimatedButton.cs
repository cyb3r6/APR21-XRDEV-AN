using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AnimatedButton : MonoBehaviour
{
    public AudioSource audioSource;

    public UnityAction OnButton;

    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;

    private Animator buttonAnim;
    
    void Awake()
    {
        buttonAnim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Pressed");
            audioSource.Play();

            //OnButtonPressed();
            OnButton?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Released");
        }
    }
}
