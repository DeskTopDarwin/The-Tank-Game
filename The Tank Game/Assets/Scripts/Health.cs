using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float hp;
    public float Hp
    {
        get { return hp; } 
        set { hp = value; }
    }
    public float maxHealth;

    public bool isDead;

    private void Start()
    {
        Hp = maxHealth;
        isDead = false;
    }

    public void TakeDamage(float value)
    {
        Hp -= value;
        if (Hp < 0)
        {
            Hp = 0;
        }

        if (Hp <= 0)
        {
            isDead = true;
        }
    }
}
