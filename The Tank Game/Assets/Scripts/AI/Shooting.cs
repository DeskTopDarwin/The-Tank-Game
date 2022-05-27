using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int friendlyUnitNumber = 1;
    public int enemyUnitNumber = 2;
    public int unitNumber;

    public int maxSearchingRange;

    public Transform target;
    public float delayFindTarget = 5;
    public float currentCountDownToFindNewTarget;

    public GameObject bulletPrefab;
    public float bulletVelocity;
    public float reloadTime;
    public float currentReloadTime;
    public Transform gunTip;

    public Health selfHealth;

    public static HashSet<Transform> alliedUnits = new HashSet<Transform>();
    public static HashSet<Transform> enemyUnits = new HashSet<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        var unitScript = GetComponent<Unit>();
        if (unitScript != null)
        {
            unitNumber = unitScript.UnitNumber;
        }

        selfHealth = GetComponent<Health>();
        if (selfHealth == null)
        {
            Debug.LogError("Health script must be present in unit");
        }

        currentCountDownToFindNewTarget = delayFindTarget;
        currentReloadTime = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Make it find target every 5 second

        
    }

    /// <summary>
    /// Return a target if a target is available, if no target availabe returns null
    /// </summary>
    /// <returns></returns>
    private HashSet<Transform> FindPossibleInRangeTargets()
    {
        HashSet<Transform> possibleTargets = new HashSet<Transform>();
        //float closesTargetDistance = float.MaxValue;

        //allied unit checks for closes enemy
        if (unitNumber == friendlyUnitNumber)
        {
            foreach (var unit in enemyUnits)
            {
                Transform tempValue = CheckPossibleInRangeUnit(unit);
                if (tempValue != null)
                {
                    possibleTargets.Add(tempValue);
                }
            }
        }

        //enemy unit checks for closes allied unit
        if (unitNumber == enemyUnitNumber)
        {
            foreach (var unit in alliedUnits)
            {
                Transform tempValue = CheckPossibleInRangeUnit(unit);
                if (tempValue != null)
                {
                    possibleTargets.Add(tempValue);
                }
            }
        }
        return possibleTargets;
    }

    /// <summary>
    /// Checks within the possible targets witch is available to shoot, aka no obstruction between the shooter
    /// and the target.
    /// </summary>
    /// <param name="inRangeTargets"></param>
    /// <returns></returns>
    private HashSet<Transform> FindAvailableTargetsToShoot(HashSet<Transform> inRangeTargets)
    {
        //checks if the collection is empty
        if (inRangeTargets == null)
        {
            Debug.Log("In range target is empty and null. If not intended a bug is present.");
            return null;
        }

        HashSet<Transform> availableTargets = new HashSet<Transform>();

        foreach (var unit in inRangeTargets)
        {
            Vector3 direction = unit.transform.position - transform.position;

            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, direction, out hit))
            {
                Unit unitScript = hit.transform.GetComponent<Unit>();

                if (unitScript != null)
                {
                    availableTargets.Add(unitScript.transform);
                }
            }
        }

        return availableTargets;
    }

    /// <summary>
    /// Get final target, aka the closest available to shoot target.
    /// </summary>
    /// <param name="availableTargets"></param>
    private void FindClosestAvailableTarget(HashSet<Transform> availableTargets)
    {
        if (availableTargets == null)
        {
            Debug.Log("No available targets to shoot, if unintended, bug present in FindAvailableTargetsToShoot()");
        }

        float closestDistance = float.MaxValue;
        Transform possibleFinalTarget = null;

        foreach (var unit in availableTargets)
        {
            Transform tempValue = CheckIfClosestUnit(unit, closestDistance, out closestDistance);
            if (tempValue != null)
            {
                possibleFinalTarget = tempValue;
            }
        }

        target = possibleFinalTarget;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="unit"></param>
    /// <param name="closesDistance"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    private Transform CheckIfClosestUnit(Transform unit, float closesDistance, out float distance)
    {
        Transform target = null;
        Vector3 vectorDistance = unit.transform.position - transform.position;
        //float magnitude = vectorDistance.magnitude;

        if (vectorDistance.magnitude < closesDistance)
        {
            distance = vectorDistance.magnitude;
            //distance = closesDistance;
            target = unit;
        }

        else
            distance = closesDistance;

        return target;
    }

    /// <summary>
    /// If unit is within maximum range, returns the transform.
    /// Else returns null.
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    private Transform CheckPossibleInRangeUnit(Transform unit)
    {
        Transform possibleTarget = null;
        Vector3 vectorDistance = unit.transform.position - transform.position;
        float magnitude = vectorDistance.magnitude;

        if (magnitude <= maxSearchingRange)
        {
            possibleTarget = unit;
        }

        return possibleTarget;
    }


    /// <summary>
    /// Will pause the nav mesh of the unit if a target is found
    /// </summary>
    private void MovementPause()
    {
        Navigation nav = GetComponent<Navigation>();
        if (target != null)
        {
            if (nav != null)
            {
                nav.PauseTheUnit(true);
            }
        }

        if (target == null)
        {
            nav.PauseTheUnit(false);
        }
    }


    private void EngagingTarget()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;

            //set rotation too look at target aka take aim
            transform.transform.rotation = Quaternion.LookRotation(direction);

            //create a bullet and add velocity to it
            if (currentReloadTime <= 0)
            {
                currentReloadTime = reloadTime;
                GameObject bullet = Instantiate(bulletPrefab, gunTip.transform.position, Quaternion.Euler(direction));
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = bullet.transform.forward * bulletVelocity;
                bulletRB.useGravity = true;
            }
        }
    }

    private void ReloadTimer()
    {
        currentReloadTime -= Time.deltaTime;
        currentCountDownToFindNewTarget -= Time.deltaTime;
    }


    private void CheckIfTargetIsAlive()
    {
        Health health = target.GetComponent<Health>();

        if (health != null)
        {
            if (health.isDead)
            {
                RemoveUnitFromCollection(target);
                target = null;
            }
        }
    }

    private void ShootBrain()
    {
        //after a few seconds should loook for a target
        if (currentCountDownToFindNewTarget <= 0)
        {
            currentCountDownToFindNewTarget = delayFindTarget;
            //find target within max detection range

            HashSet<Transform> inRangetargets = FindPossibleInRangeTargets();

            //find witch targets are available to shoot via raycast to check for obstruction

            HashSet<Transform> availableTargets = FindAvailableTargetsToShoot(inRangetargets);

            //find the closes one of the available targets

            FindClosestAvailableTarget(availableTargets);
        }

        // if a target is found do the rest
        if (target != null)
        {
            //pause the unit movement
            MovementPause();
            //Shoot the unit of opposite side
            EngagingTarget();
            
            //checks if target is still alive
            CheckIfTargetIsAlive();
            //if no opposite side units are available to shoot, resume movement.
        }

        //time for gun reload
        ReloadTimer();
    }

    public void AddUnitToCollection(Transform unit)
    {

    }

    public void RemoveUnitFromCollection(Transform unit)
    {

    }

}
