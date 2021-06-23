using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public Target targetPrefab;
    public Collider spawnAreaCollider;

    void Start()
    {
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        var spawnedTarget = Instantiate(targetPrefab, RandomTargetPosition(), targetPrefab.transform.rotation);

        spawnedTarget.spawnArea = this;
    }

    private Vector3 RandomTargetPosition()
    {
        float xvalue = Random.Range(spawnAreaCollider.bounds.min.x, spawnAreaCollider.bounds.max.x);
        float yValue = Random.Range(spawnAreaCollider.bounds.min.y, spawnAreaCollider.bounds.max.y);
        float zValue = Random.Range(spawnAreaCollider.bounds.min.z, spawnAreaCollider.bounds.max.z);

        return new Vector3(xvalue, yValue, zValue);
    }


}
