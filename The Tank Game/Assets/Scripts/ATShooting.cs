using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Navigation))]
public class ATShooting : MonoBehaviour
{
    public Transform player;
    public Transform gunTip;
    public GameObject ATRocketPrefab;

    public bool isShooting;
    public float bulletVelocity;
    public float targetingDistance;
    public float firingSpeed;
    private float currentReload;

    private Navigation nav;

    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<Navigation>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
        TargetingBrain();
    }

    private void TimerUpdate()
    {
        currentReload -= Time.deltaTime;
    }

    private void TargetingBrain()
    {
        isShooting = false;
        Vector3 vectorDistance = player.transform.position - transform.position;
        float magnitude = vectorDistance.magnitude;

        if (magnitude <= targetingDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(gunTip.position, vectorDistance, out hit))
            {
                //Debug.DrawRay(gunTip.position, direction * hit.distance, Color.red);
                PlayerHealth playerhpScript = hit.transform.GetComponent<PlayerHealth>();

                if (playerhpScript != null)
                {
                    isShooting = true;
                    if (currentReload <= 0)
                    {
                        currentReload = firingSpeed;
                        GameObject bullet = Instantiate(ATRocketPrefab, gunTip.transform.position, Quaternion.LookRotation(vectorDistance));
                        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                        bulletRB.velocity = bullet.transform.forward * bulletVelocity;
                        bulletRB.useGravity = false;
                    }
                }
            }
        }
        if (isShooting)
        {
            nav.PauseTheUnit(true);
        }
    }
}
