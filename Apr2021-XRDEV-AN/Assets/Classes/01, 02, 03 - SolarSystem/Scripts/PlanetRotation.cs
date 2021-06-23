using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Vector3 axisOfRotation; // (x, y, z)
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start has been called");
    }




    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axisOfRotation * Time.deltaTime * speed);
    }
}
