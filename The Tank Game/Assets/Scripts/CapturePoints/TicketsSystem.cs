using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TicketsSystem : MonoBehaviour
{
    public int alliedTickets;
    public int enemyTickets;
    public int maxTickets;
    public int pointsToDeplete;

    public int pointsControlledAlly;
    public int pointsControlledEnemy;

    public float timeCountDown;
    public float currentTimeCountDown;

    private List<CaptureScript> capturePoints = new List<CaptureScript>();

    // Start is called before the first frame update
    void Start()
    {
        capturePoints = FindObjectsOfType<CaptureScript>().ToList();
        currentTimeCountDown = timeCountDown;
        alliedTickets = maxTickets;
        enemyTickets = maxTickets;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPointsControl();
        TimersCountDown();
        BleedTickets();
    }

    private void CheckPointsControl()
    {
        //simple reset to not have to verify when a point isnt owned anymore
        pointsControlledAlly = 0;
        pointsControlledEnemy = 0;
        foreach (var point in capturePoints)
        {
            //count point owned by allies
            if (point.CaptureLocked && point.pointOwner == CaptureScript.PointOwner.Allied)
            {
                pointsControlledAlly++;
            }
            //count point owned by enemy
            if (point.CaptureLocked && point.pointOwner == CaptureScript.PointOwner.Enemy)
            {
                pointsControlledEnemy++;
            }
        }
    }

    private void BleedTickets()
    {
        if (currentTimeCountDown <= 0)
        {
            currentTimeCountDown = timeCountDown;
            if (pointsControlledAlly > pointsControlledEnemy)
            {
                //remove tickets to enemy
                enemyTickets -= pointsToDeplete;
            }

            if (pointsControlledEnemy > pointsControlledAlly)
            {
                //remove tickets to allies
                alliedTickets -= pointsToDeplete;
            }
        }
    }

    private void TimersCountDown()
    {
        currentTimeCountDown -= Time.deltaTime;
    }

}
