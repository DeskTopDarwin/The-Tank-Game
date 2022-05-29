using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage;
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("object hit: " + collision.gameObject.name);
    //    Health gameObjectHit = collision.gameObject.GetComponent<Health>();
    //    if (gameObjectHit != null)
    //    {
    //        //Debug.Log("Bullet hit for: " + damage);
    //        gameObjectHit.TakeDamage(damage);
    //    }
    //}

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, ~LayerMask.GetMask("CapturePoint")))
        {
            //Debug.Log("object hit: " + hit.transform.name);
            Health gameObjectHit = hit.transform.GetComponent<Health>();
            if (gameObjectHit != null)
            {
                Debug.Log("hit: " + hit.transform.name);
                //Debug.Log("Bullet hit for: " + damage);
                gameObjectHit.TakeDamage(damage);
            }
            Destroy(gameObject);
        }    
    }

    //public BulletType type;
    //
    //private float bulletDamage;
    //private float shellDamage;
    //
    //public enum BulletType
    //{
    //    Bullet,
    //    Shell
    //}
    //
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Health gameObjectHit = collision.gameObject.GetComponent<Health>();
    //    if (gameObjectHit == null)
    //        return;
    //
    //    if (type == BulletType.Bullet)
    //    {
    //        gameObjectHit.TakeDamage(bulletDamage);
    //        return;
    //    }
    //
    //    if (type == BulletType.Shell)
    //    {
    //        gameObjectHit.TakeDamage(shellDamage);
    //    }
    //}
}
