using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public AnimatedButton animatedButton;
    private ParticleSystem particleSystem;

    
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();

        animatedButton.OnButton += RainFall;
    }

    public void RainFall()
    {
        particleSystem.Play();
    }
   
}
