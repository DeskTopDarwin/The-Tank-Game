using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public BulletType type;

    private float bulletDamage;
    private float shellDamage;
    
    public enum BulletType
    {
        Bullet,
        Shell
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health gameObjectHit = collision.gameObject.GetComponent<Health>();
        if (gameObjectHit == null)
            return;

        if (type == BulletType.Bullet)
        {
            gameObjectHit.TakeDamage(bulletDamage);
            return;
        }

        if (type == BulletType.Shell)
        {
            gameObjectHit.TakeDamage(shellDamage);
        }
    }

}
