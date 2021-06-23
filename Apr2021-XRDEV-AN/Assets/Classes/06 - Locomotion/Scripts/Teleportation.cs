using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform xRRig;
    public float midpointHeight;
    [Range(5, 50)] 
    public int lineResolution;
    public GameObject teleportReticle;
    public float smoothAmount = 2;

    private VRinput controller;
    private LineRenderer line;
    private Vector3 hitPosition;
    private Vector3 hitNormal;
    private Vector3 smoothedEndPosition;
    private bool shouldTeleport = false;
    
    void Start()
    {
        controller = GetComponent<VRinput>();
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        line.positionCount = lineResolution +1;
        teleportReticle.SetActive(false);

        controller.OnThumbstickUpdated.AddListener(RaycastTeleport);
        controller.OnThumbstickUp.AddListener(Teleport);
    }

    
    
    public void RaycastTeleport()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Vector3 desiredPosition = hit.point;
            Vector3 directionToDesiredPosition = (desiredPosition - hitPosition) / smoothAmount;
            smoothedEndPosition = hitPosition + directionToDesiredPosition;


            CurveLine(smoothedEndPosition);

            hitPosition = smoothedEndPosition;
            hitNormal = hit.normal;

            teleportReticle.transform.position = smoothedEndPosition;
            teleportReticle.transform.LookAt(hitNormal + smoothedEndPosition);

            //line.SetPosition(0, transform.position);
            //line.SetPosition(1, hitPosition);
            teleportReticle.SetActive(true);
            line.enabled = true;
            shouldTeleport = true;
        }
    }

    public void Teleport()
    {
        if(shouldTeleport == true)
        {
            xRRig.position = hitPosition;

            // visuals
            line.enabled = false;
            shouldTeleport = false;
            teleportReticle.SetActive(false);
        }
    }

    private void CurveLine(Vector3 hitPoint)
    {
        Vector3 startPosition = controller.transform.position;
        Vector3 endPosition = hitPoint;
        Vector3 midPosition = (endPosition - startPosition) / 2 + startPosition;

        midPosition.y += midpointHeight;

        for (int i = 0; i <= lineResolution; i++)
        {
            float t = (float)i / (float)lineResolution;
            Vector3 startToMid = Vector3.Lerp(startPosition, midPosition, t);
            Vector3 midToEnd = Vector3.Lerp(midPosition, endPosition, t);
            Vector3 curvePosition = Vector3.Lerp(startToMid, midToEnd, t);

            line.SetPosition(i, curvePosition);
        }
    }
}
