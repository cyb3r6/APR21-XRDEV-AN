using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed;
    public float distance;
    public SpawnArea spawnArea;

    private float startingPosition;

    void Start()
    {
        startingPosition = transform.position.x;
    }

    
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = startingPosition + Mathf.Sin(Time.time * moveSpeed) * distance;
        transform.position = currentPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var food = collision.collider.GetComponent<GrabbableObject>();
        if(food)
        {
            Destroy(food.gameObject);
            Destroy(this.gameObject);

            spawnArea.SpawnTarget();
        }
    }
}
