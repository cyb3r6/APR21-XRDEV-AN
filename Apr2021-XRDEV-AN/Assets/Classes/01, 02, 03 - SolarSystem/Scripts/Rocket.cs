using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rocketRigidBody;
    public GameObject laserPrefab;
    public Transform spawnPoint;
    public float shootingForce;

    void Start()
    {
        // keep the mouse inside of the game view
        //Cursor.lockState = CursorLockMode.Locked;

        rocketRigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        #region Translational movement

        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        //}

        //transform.Rotate(Vector3.up * horizontal * turnSpeed);
        //transform.Rotate(Vector3.left * vertical * turnSpeed);

        #endregion

        #region Physics

        Vector3 horizontalVector = new Vector3(0f, horizontal * Time.deltaTime * turnSpeed , 0f);
        Vector3 verticalVector = new Vector3(vertical * Time.deltaTime * turnSpeed, 0f,0f);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            // horizontal
            rocketRigidBody.AddRelativeTorque(horizontalVector);

            // vertical
            rocketRigidBody.AddRelativeTorque(verticalVector);
        }

        // move forward
        if (Input.GetKey(KeyCode.W))
        {
            rocketRigidBody.AddForce(transform.forward * moveSpeed);
        }

        // move backward
        if (Input.GetKey(KeyCode.S))
        {
            rocketRigidBody.AddForce(-transform.forward * moveSpeed);
        }
        // move left
        if (Input.GetKey(KeyCode.A))
        {
            rocketRigidBody.AddForce(-transform.right * moveSpeed);
        }
        // move right
        if (Input.GetKey(KeyCode.D))
        {
            rocketRigidBody.AddForce(transform.right * moveSpeed);
        }

        #endregion

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootLaser();
        }
    }

    private void ShootLaser()
    {
        GameObject laser = Instantiate(laserPrefab,spawnPoint.position,spawnPoint.rotation);
        Rigidbody laserRigidBody = laser.GetComponent<Rigidbody>();
        laserRigidBody.AddForce(laser.transform.forward * shootingForce);
        Destroy(laser, 5);
    }

}
