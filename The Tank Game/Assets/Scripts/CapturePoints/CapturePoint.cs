using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{

    static public int alliedPoints;
    static public int EnemyPoints;
    static private int orginalAmountPoints;

    private BoxCollider captureZone;
    private float capturePourcentage;

    private int alliedUnitsPresent;
    private int enemyUnitsPresent;

    private CaptureStatus captureStatus;
    public BelongingTeam team;


    void Start()
    {
        captureZone = GetComponent<BoxCollider>();
        team = BelongingTeam.NEUTRAL;
    }

    // Update is called once per frame
    void Update()
    {
        CaptuePointBrain();
    }

    private void OnCollisionStay(Collision collision)
    {
        //reset values every frame
        alliedUnitsPresent = 0;
        enemyUnitsPresent = 0;  

        //Counting of the units in the point.
        foreach (var contact in collision.contacts)
        {
            // Verify if could be done less expensively
            int unitTeamNumber = contact.thisCollider.GetComponent<Unit>().unitNumber;
            // Value is either 1 or 2. The unit number represent witch team they belong to. 
            if (unitTeamNumber == 1)
                alliedUnitsPresent++;   
            if (unitTeamNumber == 2)
                enemyUnitsPresent++;
        }
    }

    /// <summary>
    /// Perform capturing logic according to the units present in the point.
    /// </summary>
    private void CaptuePointBrain()
    {
        if (alliedUnitsPresent == 0 && enemyUnitsPresent == 0)
            return;

        //Capture point in conflict
        if (alliedUnitsPresent > 0 && enemyUnitsPresent > 0)
        {
            InConflict();
            return;
        }

        //allied capture
        if (alliedUnitsPresent > 0 && enemyUnitsPresent == 0)
        {
            InCapture(BelongingTeam.ALLIED);
            return;
        }

        //enemy capture
        if (alliedUnitsPresent == 0 && enemyUnitsPresent > 0)
        {
            InCapture(BelongingTeam.ENEMY);
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="team"></param>
    private void InCapture(BelongingTeam team)
    {

        //Decapture from enemy
        if (this.team == BelongingTeam.ENEMY && team == BelongingTeam.ALLIED)
        {
            DeCapture();
        }

        //Decapture from ally
        if (this.team == BelongingTeam.ALLIED && team == BelongingTeam.ENEMY)
        {
            DeCapture();
        }

        //fresh capture
        if (this.team == BelongingTeam.NEUTRAL)
        {

        }
    }

    private void InConflict()
    {
        //decreases pourcentage over time t'ill it reaches 0 and stays at 0 
        //if conflict resolved, should resume capturing


    }

    private void DeCapture()
    {
        //Point belongs to opposite therefor, the decapping has to bring down the the capture pourcentage to 0 to begin capturing
    }


    //Needed 
    private enum CaptureStatus
    {
        INCAPTURE,
        CAPTURED,
        DECAPTURE,
        CONFLICT
    };

    public enum BelongingTeam
    {
        ALLIED,
        ENEMY,
        NEUTRAL
    };
}