using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public float spawningOffset;
    public int numberToSpawnAtStart;

    public int maxUnitsOnMap;
    private int currentAmountUnitOnMap;
    public float spawningTimeIntervalDuringGame;
    public int unitToSpawnEachCycle;
    private float currentTimerSpawning;
    

    public float unitHealth;

    public int friendlyUnitNumber;
    public int enemyUnitNumber;

    public Transform alliedSpawn;
    public Transform enemySpawn;

    public GameObject AlliedUnitPrefab;
    public GameObject EnemyUnitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberToSpawnAtStart; i++)
        {
            SpawnAlliedUnit();
            SpawnEnemyUnit();
        }
        currentTimerSpawning = spawningTimeIntervalDuringGame;
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountDown();
        if (currentTimerSpawning <= 0)
        {
            currentTimerSpawning = spawningTimeIntervalDuringGame;
            if (currentAmountUnitOnMap < maxUnitsOnMap)
            {
                for (int i = 0; i < unitToSpawnEachCycle; i++)
                {
                    SpawnAlliedUnit();
                    SpawnEnemyUnit();
                }
            }
        }
        //Debug.Log("ammount of unit spawned according to what spawned: " + currentAmountUnitOnMap);
    }

    private void TimerCountDown()
    {
        currentTimerSpawning -= Time.deltaTime; 
    }


    private Vector3 OffSetDestination(Vector3 target)
    {
        //Debug.Log("True orginal target: " + target);

        double valX = target.x + (Random.value * (spawningOffset - -spawningOffset) + -spawningOffset);
        target.x = (float)valX;

        double valZ = target.z + (Random.value * (spawningOffset - -spawningOffset) + -spawningOffset);
        target.z = (float)valZ;

        //Debug.Log("After offset mod: " + target);

        return target;
    }


    private void SpawnAlliedUnit() 
    {
        //Debug.Log("Spawned allied unit");
        currentAmountUnitOnMap++;

        Vector3 spawnPoint = alliedSpawn.position;
        spawnPoint = OffSetDestination(spawnPoint);

        GameObject spawnedUnit = Instantiate(AlliedUnitPrefab, spawnPoint, Quaternion.identity);
        spawnedUnit.GetComponent<Unit>().UnitNumber = friendlyUnitNumber;
        spawnedUnit.GetComponent<Health>().maxHealth = unitHealth;
        //Shooting shootingScript = spawnedUnit.GetComponent<Shooting>(); 
        //shootingScript.

    }

    private void SpawnEnemyUnit()
    {
        //Debug.Log("Spawned enemy unit");
        currentAmountUnitOnMap++;

        Vector3 spawnPoint = enemySpawn.position;
        spawnPoint = OffSetDestination(spawnPoint);

        GameObject spawnedUnit = Instantiate(EnemyUnitPrefab, spawnPoint, Quaternion.identity);
        spawnedUnit.GetComponent<Unit>().UnitNumber = enemyUnitNumber;
        spawnedUnit.GetComponent<Health>().maxHealth = unitHealth;
    }

    public void RemoveSpawnedUnitCount(int value)
    {
        if (currentAmountUnitOnMap > 0)
        {
            currentAmountUnitOnMap -= value;
            if (currentAmountUnitOnMap < 0)
            {
                currentAmountUnitOnMap = 0;
            }
        }
    }
}
