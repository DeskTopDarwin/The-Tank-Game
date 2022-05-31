using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawning : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnlocation;
    public float health;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(playerPrefab, spawnlocation.position, Quaternion.identity);
        player.GetComponent<Unit>().UnitNumber = 1;
        player.GetComponent<Health>().maxHealth = health;
        //player;
    }
}
