using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    
    public GameObject turret;
    public GameObject cannon;
    public Camera camera;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        setTurretRotation();
    }

    private void setTurretRotation()
    {
        float angle = camera.transform.eulerAngles.y;
        //Debug.Log("camera angle: " + camera.transform.rotation.y + ", " + Quaternion.Euler(0, angle, 0));
        turret.transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    private void setElevatationOnTurret()
    {

    }

    private float angleBetweenGameObjects()
    {
        Vector2 x = new Vector2(camera.transform.position.x, camera.transform.position.z); 
        Vector2 y = new Vector2(turret.transform.position.x, turret.transform.position.z);
        return Vector2.Angle(y,x);
    }
}
