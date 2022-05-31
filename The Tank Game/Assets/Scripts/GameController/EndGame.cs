using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    public GameObject ticketsController;
    //public bool gameEnded;
    private TicketsSystem ticketsSystem;

    public GameObject WinText;
    public GameObject LostText;
    
    

    // Start is called before the first frame update
    void Start()
    {
        ticketsSystem = ticketsController.GetComponent<TicketsSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ticketsSystem.alliedTickets <= 0 || player.GetComponent<PlayerHealth>().playerDead)
        {
            //lose
            LostText.SetActive(true);
            DisablePlayer();
            
        }

        if (ticketsSystem.enemyTickets <= 0)
        {
            //game won
            WinText.SetActive(true);
            DisablePlayer();
        }
    }

    private void DisablePlayer()
    {
        player.GetComponent<TurretMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<TankShooting>().enabled = false;
        player.GetComponent<MouseLock>().enabled = false;
    }
}
