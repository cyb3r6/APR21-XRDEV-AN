using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : GrabbableObject
{
    /// <summary>
    /// This is to show the angle of the lever value
    /// changing
    /// </summary>
    public float leverAngle;

    /// <summary>
    /// This is to override the center of mass on the rigidbody
    /// </summary>
    public Vector3 centerOfMass;

    [SerializeField]
    private HingeJoint myJoint;
    
    void Start()
    {
        rigidBody.centerOfMass = centerOfMass;
    }

    public override void OnUpdatingInteraction()
    {
        leverAngle = NormalizedJointAngle();
    }

    /// <summary>
    /// With the forward vector of the lever pointing up
    /// We'll have minAngle \ forward vector / maxAngle
    /// We have to normalize the angle between the forward vector and angles
    /// If the joints angle is a zero, it's pointing straight up
    /// in the forward direction.
    /// </summary>
    /// <returns></returns>
    public float NormalizedJointAngle()
    {
        float normalizedAngle = myJoint.angle / myJoint.limits.max;
        return normalizedAngle;
    }
}
