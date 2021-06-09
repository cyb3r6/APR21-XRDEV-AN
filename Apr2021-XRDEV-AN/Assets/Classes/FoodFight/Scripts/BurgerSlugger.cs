using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSlugger : GrabbableObject
{
    public List<GameObject> foodPrefabs = new List<GameObject>();
    public Transform spawnPoint;
    public float shootingForce = 1000f;
    public int foodIndex = 0;

    public override void OnInteraction()
    {
        GameObject food = Instantiate(foodPrefabs[foodIndex], spawnPoint.position, spawnPoint.rotation);
        Rigidbody laserRigidBody = food.GetComponent<Rigidbody>();
        laserRigidBody.AddForce(food.transform.forward * shootingForce);

        foodIndex = Random.Range(0, foodPrefabs.Count);
    }
}
