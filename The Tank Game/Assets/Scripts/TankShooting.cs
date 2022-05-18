using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public float cannonReloadSpeed;
    public float mgsReloadSpeed;
    public int _shellAmmo;
    public int _mgsAmmo;
    public float cannonRecoilForce;

    public GameObject cannon;

    private float cannonCurrentReload;
    private float mgsCurrentReload;

    private Rigidbody rigidbody;
    
    public int ShellAmmo
    {
        get { return _shellAmmo; }
        set 
        {
            if (value < 0)
            {
                _shellAmmo = 0;
            }
            else
            {
                _shellAmmo = value;
            }
        }
    }
    public int MgsAmmo
    {
        get { return _mgsAmmo; }
        set
        {
            if(value < 0)
            {
                _mgsAmmo = 0;
            }
            else
            {
                _mgsAmmo = value;
            }
        }
    }


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
    }

    
    void Update()
    {
        countdown();
        ShootingTrigger();
    }

    private void ShootingTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ShellAmmo > 0)
            {
                ShootCannon();
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (MgsAmmo > 0)
            {
                ShootMgs();
            }
        }
    }

    private void countdown()
    {
        cannonCurrentReload -= Time.deltaTime;
        mgsCurrentReload -= Time.deltaTime;
    }

    private void ShootCannon()
    {
        if (cannonCurrentReload <= 0)
        {
            ShellAmmo--;
            cannonCurrentReload = cannonReloadSpeed;
            rigidbody.AddForce(-cannon.transform.forward * cannonRecoilForce, ForceMode.Impulse);


        }
    }

    private void ShootMgs()
    {
        if (mgsCurrentReload <= 0)
        {
            MgsAmmo--;
            mgsCurrentReload = mgsReloadSpeed;
        }
    }
}
