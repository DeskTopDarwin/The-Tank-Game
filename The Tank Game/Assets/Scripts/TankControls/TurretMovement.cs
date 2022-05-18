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
    //private Transform target;
    //private RaycastHit hit;

    
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
        Vector3 target;

        if (Physics.Raycast(ray, out hit,9999,~LayerMask.GetMask("CapturePoint", "Tank")))
        {
            target = hit.point;
            //Debug.Log("hit something");
        }
        else
        {
            //Transform Temptransform = camera.transform;
            //Temptransform.position = new Vector3(Temptransform.position.x, Temptransform.position.y, Temptransform.position.z * 1000);
            target = camera.transform.forward * 100;
            //Debug.Log("camera trnaforgm thingy");
        }
        
        Vector3 distanceBetweenCannonCamera =  camera.transform.position - cannon.transform.position;
        Vector3 distanceBetweenCannonTarget = target - cannon.transform.position;
        Vector3 distanceBetweenCameraTarget = target - camera.transform.position;

        float distanceA = distanceBetweenCannonTarget.magnitude; 
        float distanceB = distanceBetweenCannonCamera.magnitude;
        float distanceC = distanceBetweenCameraTarget.magnitude;

        float v = Mathf.Pow(distanceA, 2f) + Mathf.Pow(distanceB, 2f) - Mathf.Pow(distanceC, 2f);

        float angleC = Mathf.Acos(v / (2 * (distanceA * distanceB)));
        float angleCDeg = angleC * Mathf.Rad2Deg;

        float heightOppsite = camera.transform.position.y - cannon.transform.position.y;

        float angleOpposedToCannon = Mathf.Sin(heightOppsite / distanceB);
        float angleOpposedToCannonDeg = angleOpposedToCannon * Mathf.Rad2Deg;

        cannonElevation = 180 + (angleOpposedToCannonDeg + angleCDeg);

        //cannonElevation = Mathf.Clamp(cannonElevation, -15, 15);

        cannon.transform.rotation = Quaternion.Euler(cannonElevation, cameraAngle, 0);


        //
        //Debug.DrawLine(camera.transform.position, cannonDirection);
        //
        //Debug.Log("direction of cannon: " + cannonDirection);
        //
        //cannonElevation = Mathf.Sin(cannonDirection.y / cannonDirection.magnitude);
        //cannonElevation = Mathf.Clamp(cannonElevation, -15, 15);
        //Debug.Log("angle of the cannon: " + cannonElevation);
        //
        //cannon.transform.rotation = Quaternion.Euler(cannonElevation, cameraAngle, 0);

    }

    //private float angleBetweenGameObjects()
    //{
    //    Vector2 x = new Vector2(camera.transform.position.x, camera.transform.position.z); 
    //    Vector2 y = new Vector2(turret.transform.position.x, turret.transform.position.z);
    //    return Vector2.Angle(y,x);
    //}
}
