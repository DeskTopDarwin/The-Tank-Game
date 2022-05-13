using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health
    {
        get { return health; } 
        private set { health = value; }
    }
    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float value)
    {
        health -= value;
        if (health < 0)
        {
            health = 0;
        }
    }
}
