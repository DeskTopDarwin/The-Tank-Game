using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Unit>().UnitNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
