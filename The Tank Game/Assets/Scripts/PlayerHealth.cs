using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float hp;
    public float PlayerHP
    {
        get { return hp; }
        private set { hp = value; }
    }

    public bool playerDead;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = maxHealth;
        playerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHP <= 0)
        {
            playerDead = true;
        }
    }

    public void PlayerTakeDamage(float value)
    {
        PlayerHP -= value;  
    }
}
