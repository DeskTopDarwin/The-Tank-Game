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
        //float angle = angleBetweenGameObjects();
        //Debug.Log(angle);
        //turret.transform.rotation = Quaternion.Euler(0, angle, 0);
        ////Debug.Log(turret.transform.rotation);
    }


    private float angleBetweenGameObjects()
    {
        Vector2 x = new Vector2(camera.transform.position.x, camera.transform.position.z); 
        Vector2 y = new Vector2(turret.transform.position.x, turret.transform.position.z);
        //Debug.Log(y);
        //Debug.Log(x);
        
        return Vector2.Angle(y,x);
    }

    /*
    float angle_of_vector(Vector2 vector_A, Vector2 vector_B)
    {
        float scalar_product = dot_product(vector_A, vector_B);
        float lenght_A = Mathf.Sqrt(square_of_value(vector_A.x) + square_of_value(vector_A.y));
        float lenght_B = Mathf.Sqrt(square_of_value(vector_B.x) + square_of_value(vector_B.y));
        float cos_alpha = scalar_product / (lenght_A * lenght_B);
        float angle = Mathf.Acos(cos_alpha);

        Debug.Log(angle);
        if (cross_product(vector_A, vector_B) < 0)
        {
            return 2 * Mathf.PI - angle;
        }
        else
        {
            return angle;
        }
    }

    float dot_product(Vector2 vector_A, Vector2 vector_B)
    {
        return (vector_A.x * vector_B.x) + (vector_A.y * vector_B.y);
    }

    float cross_product(Vector2 vector_A, Vector2 vector_B)
    {
        return (vector_A.x * vector_B.y) - (vector_A.y * vector_B.x);
    }

    float square_of_value(float value)
    {
        return value * value;
    }
    */
}
