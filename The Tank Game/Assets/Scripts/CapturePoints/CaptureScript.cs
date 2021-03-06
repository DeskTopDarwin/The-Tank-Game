using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScript : MonoBehaviour
{
    public PointOwner pointOwner;
    public float captureRate;
    public float deCaptureRate;

    public int alliedUnitsPresent;
    public int enemyUnitsPresent;
    
    public float maxValueOfCapture = 100f;
    public float minValueOfCapture = -100f;
    public bool IsInCapture;
    
    public bool _captureLocked;
    public bool CaptureLocked
    {
        get
        {
            return _captureLocked;
        }
        private set
        {
            _captureLocked = value;
        }

    }

    public float _captureValue;
    public float CaptureValue
    {
        get
        {
            return _captureValue;
        }

        private set 
        {
            _captureValue = Mathf.Clamp(value, minValueOfCapture, maxValueOfCapture);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CaptureValue = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_captureValue);
        //CaptureValue++;
        //if capture has not reached a value of capture (either -100 or 100) captureValue should go back down to 0 over time
        if (!CaptureLocked && !IsInCapture)
        {
            if (CaptureValue != 0)
            {
                if (CaptureValue > 0)
                {
                    CaptureValue -= deCaptureRate * Time.deltaTime;
                }
        
                if (CaptureValue < 0 )
                {
                    CaptureValue += deCaptureRate * Time.deltaTime;
                }
            }
        }

        //if units are present in point, it shall capture to the appropriate side.
        // if both sides are present it
        if (alliedUnitsPresent != 0 || enemyUnitsPresent !=0 )
        {
            //allies capture
            if (enemyUnitsPresent == 0 && CaptureValue < maxValueOfCapture)
            {
                IsInCapture = true;
                //CaptureValue++;
                CaptureValue += captureRate * alliedUnitsPresent * Time.deltaTime;
                if (CaptureValue > maxValueOfCapture - 0.5f) 
                {
                    Lock(true);
                    pointOwner = PointOwner.Allied;
                }
            }

            //enemies capture
            if (alliedUnitsPresent == 0 && CaptureValue > minValueOfCapture)
            {
                IsInCapture = true;
                CaptureValue -= captureRate * enemyUnitsPresent * Time.deltaTime;
                if (CaptureValue > minValueOfCapture - 0.5f)
                {
                    Lock(true);
                    pointOwner = PointOwner.Enemy;
                }
            }
        }

        //attempt to resolve ownership
        //if (alliedUnitsPresent == 0 && enemyUnitsPresent == 0 && !CaptureLocked)
        //{
        //    Debug.Log("point is still neutral ish");
        //    pointOwner = PointOwner.Neutral;
        //}

        //checks if point is actualy beeing captured.
        if (alliedUnitsPresent == 0 && enemyUnitsPresent == 0)
        {
            IsInCapture = false;
        }

        if (alliedUnitsPresent != 0 && enemyUnitsPresent != 0)
        {
            IsInCapture = false;
        }

        VerifyLock();
        //Debug.Log("Capture point status: " + CaptureValue + " On : " + gameObject.name);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Trigger called");
        //Debug.Log(collision.gameObject.name + " On : " + gameObject.name);
        Unit unit = collision.gameObject.GetComponent<Unit>();
        if (unit == null)
        {
            Debug.Log("unit is null");
            return;
        }

        //calls many times for no reason
        if (collision.tag == "Player")
        {
            //collision.GetComponent<Rigidbody>().isKinematic = true;
            //Debug.Log("Collision");
            // Verify if could be done less expensively
            int unitTeamNumber = unit.UnitNumber;
            //Debug.Log("unitnumber of unit entering in : " + gameObject.name + " : " + unit.UnitNumber);
            // Value is either 1 or 2. The unit number represent witch team they belong to. 
            if (unitTeamNumber == 1)
                alliedUnitsPresent++;
            if (unitTeamNumber == 2)
                enemyUnitsPresent++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Rigidbody rb = other.GetComponent<Rigidbody>();
        //if (rb != null)
        //{
        //    other.GetComponent<Rigidbody>().isKinematic = false;
        //}

        Unit unit = other.gameObject.GetComponent<Unit>();
        if (unit == null)
        {
            Debug.Log("unit is null");
            return;
        }

        //calls many times for no reason
        if (other.tag == "Player")
        {
            //collision.GetComponent<Rigidbody>().isKinematic = true;
            //Debug.Log("Collision");
            // Verify if could be done less expensively
            int unitTeamNumber = unit.UnitNumber;
            // Value is either 1 or 2. The unit number represent witch team they belong to. 
            if (unitTeamNumber == 1)
                alliedUnitsPresent--;
            if (unitTeamNumber == 2)
                enemyUnitsPresent--;
        }
    }


    private void Lock(bool value)
    {
        CaptureLocked = value;
    }

    private void VerifyLock()
    {
        //find alternative to very the lock
        if (!Mathf.Approximately(CaptureValue, maxValueOfCapture) && !Mathf.Approximately(CaptureValue, minValueOfCapture))
        {
            Lock(false);
        }
    }

    public enum PointOwner
    {
        Neutral = 0,
        Allied = 1,
        Enemy = 2
    }



}
