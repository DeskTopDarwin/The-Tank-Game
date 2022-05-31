using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resupply : MonoBehaviour
{
    public float resupplyTimeInterval;
    private float currentTimeBeforAdd;

    private CaptureScript captureScript;

    private void Start()
    {
        currentTimeBeforAdd = resupplyTimeInterval;
        captureScript = GetComponent<CaptureScript>();
    }
    private void Update()
    {
        currentTimeBeforAdd -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        TankShooting script = other.GetComponent<TankShooting>();
        if (script != null)
        {
            if (captureScript.pointOwner == CaptureScript.PointOwner.Allied)
            {
                if (currentTimeBeforAdd <= 0f)
                {
                    currentTimeBeforAdd = resupplyTimeInterval;
                    if (script.ShellAmmo < 30)
                    {
                        script.ShellAmmo++;
                    }
                    if (script.MgsAmmo < 500)
                    {
                        script.MgsAmmo += 30;
                    }
                }
            }
        }
    }
}
