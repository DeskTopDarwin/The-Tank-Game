using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float hp;
    public float Hp
    {
        get { return hp; } 
        private set { hp = value; }
    }
    public float maxHealth;
    public bool isDead;

    public float delayBeforDelete;
    private float currentDelayBeforDelete;

    private void Start()
    {
        Hp = maxHealth;
        isDead = false;
        currentDelayBeforDelete = delayBeforDelete;
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            isDead = true;
            //Debug.Log("i deded");
        }
        selfDestroy();
    }

    public void TakeDamage(float value)
    {
        //Debug.Log("took: " + value + " of damage");
        Hp -= value;
        if (Hp <= 0)
        {
            isDead = true;
        }
    }

    private void selfDestroy()
    {
        if (isDead)
        {
            currentDelayBeforDelete -= Time.deltaTime;
            if (currentDelayBeforDelete <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
