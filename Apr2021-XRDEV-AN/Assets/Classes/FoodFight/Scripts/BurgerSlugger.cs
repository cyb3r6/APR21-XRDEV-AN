using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlugger : GrabbableObject
{
    public GameObject foodPrefab;
    public Transform spawnPoint;
    public float shootingForce = 1000f;

    public override void OnUpdatingInteraction()
    {
        GameObject food = Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody laserRigidBody = food.GetComponent<Rigidbody>();
        laserRigidBody.AddForce(food.transform.forward * shootingForce);
    }
}
