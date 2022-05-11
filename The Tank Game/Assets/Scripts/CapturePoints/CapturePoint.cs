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

        //allied capture
        if (alliedUnitsPresent > 0 && enemyUnitsPresent == 0)
        {
            InCapture(BelongingTeam.ALLIED);
        }

        //enemy capture
        if (alliedUnitsPresent == 0 && enemyUnitsPresent > 0)
        {
            InCapture(BelongingTeam.ENEMY);
        }

        //Capture point in conflict
        if (alliedUnitsPresent > 0 && enemyUnitsPresent > 0)
        {
            InConflict();
        }

    }

    /// <summary>
    /// Team number should either be 1 or 2;
    /// 1 beeing allied team,
    /// 2 beeing enemy team.
    /// </summary>
    /// <param name="team"></param>
    private void InCapture(BelongingTeam team)
    {
        //fresh capture
        if (this.team == BelongingTeam.NEUTRAL)
        {

        }

        //Decapture from enemy
        if (this.team == 0)
        {

        }

        //decapture from ally


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