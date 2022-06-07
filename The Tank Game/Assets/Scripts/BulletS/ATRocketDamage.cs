using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATRocketDamage : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, ~LayerMask.GetMask("CapturePoint")))
        {
            //Debug.Log("object hit: " + hit.transform.name);
            PlayerHealth gameObjectHit = hit.transform.GetComponent<PlayerHealth>();
            if (gameObjectHit != null)
            {
                Debug.Log("hit: " + hit.transform.name);
                //Debug.Log("Bullet hit for: " + damage);
                gameObjectHit.playerTakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
