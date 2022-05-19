using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float turningSpeed;
    public float maxSpeed;
    public float minSpeed;

    private Rigidbody tankRb;
    // Start is called before the first frame update
    void Start()
    {
        tankRb = GetComponent<Rigidbody>();

        if (tankRb == null) 
        Debug.Log(tankRb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move();
        turn();
    }
    private void move()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            tankRb.AddForce(transform.forward * speed);
            speedLimiterOnVector(tankRb.velocity);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            tankRb.AddForce(transform.forward * -speed);
            speedLimiterOnVector(tankRb.velocity);
        }
    }

    private void speedLimiterOnVector(Vector3 velocity)
    {
        velocity.y = Mathf.Clamp(velocity.y, minSpeed, maxSpeed);
        velocity.x = Mathf.Clamp(velocity.x, minSpeed, maxSpeed);
        velocity.z = Mathf.Clamp(velocity.z, minSpeed, maxSpeed);
        tankRb.velocity = velocity;
    }

    private void turn()
    {
        float turn = 0;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            tankRb.AddTorque(new Vector3(0, 300, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            tankRb.AddTorque(new Vector3(0,-300,0));
        }

        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        tankRb.MoveRotation(tankRb.rotation * turnRotation);
    }
}

