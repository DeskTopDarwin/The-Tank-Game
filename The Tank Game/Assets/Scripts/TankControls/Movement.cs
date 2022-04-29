using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float turningSpeed = 30f;

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
        //movement is glitchy as all hell needs to be redoned
        Vector3 movement = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            tankRb.AddForce(transform.forward * 500);
        }


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            tankRb.AddForce(-transform.forward * 500);
        }

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

