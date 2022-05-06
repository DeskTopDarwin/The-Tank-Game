using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    
    public GameObject turret;
    public GameObject cannon;
    public Camera camera;

    private float cameraAngle;
    private float cannonElevation;
    private Transform target;
    private RaycastHit hit;

    
    void Start()
    {
        
    }

    void Update()
    {
        setTurretRotation();
        setElevatationOnTurret();
    }

    private void setTurretRotation()
    {
        cameraAngle = camera.transform.eulerAngles.y;
        //Debug.Log("camera angle: " + camera.transform.rotation.y + ", " + Quaternion.Euler(0, angle, 0));
        turret.transform.rotation = Quaternion.Euler(0, cameraAngle, 0);
    }

    private void setElevatationOnTurret()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            target = hit.transform;
            //Debug.Log("hit something");
        }
        else
        {
            target = camera.transform;
            //Debug.Log("camera trnaforgm thingy");
        }

        Vector3 cannonDirection = target.position - cannon.transform.position;

        Debug.Log("direction of cannon: " + cannonDirection);

        cannonElevation = Mathf.Sin(cannonDirection.y / cannonDirection.magnitude);
        cannonElevation = Mathf.Clamp(cannonElevation, -15, 15);
        Debug.Log("angle of the cannon: " + cannonElevation);
        
        cannon.transform.rotation = Quaternion.Euler(cannonElevation, cameraAngle, 0);

    }

    //private float angleBetweenGameObjects()
    //{
    //    Vector2 x = new Vector2(camera.transform.position.x, camera.transform.position.z); 
    //    Vector2 y = new Vector2(turret.transform.position.x, turret.transform.position.z);
    //    return Vector2.Angle(y,x);
    //}
}
