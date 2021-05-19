using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrayableItem : MonoBehaviour
{
    void Start()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002;
        }
    }
}
