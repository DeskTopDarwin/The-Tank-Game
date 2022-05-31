using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ticketController;
    public TMP_Text MGAmmo;
    public TMP_Text ShellAmmo;
    public TMP_Text Health;

    public TMP_Text alliedTickets;
    public TMP_Text enemyTickets;

    private TicketsSystem tickets;
    private TankShooting shooting;
    private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        shooting = player.GetComponent<TankShooting>();
        health = player.GetComponent<PlayerHealth>();
        tickets = ticketController.GetComponent<TicketsSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        MGAmmo.text = "Mgs ammo: " + shooting.MgsAmmo;
        ShellAmmo.text = "Shells: " + shooting.ShellAmmo;
        Health.text = "HP: " + health.PlayerHP + "/" + health.maxHealth;
        alliedTickets.text = "Allied Points: " + tickets.alliedTickets;
        enemyTickets.text = "Enemy Points: " + tickets.enemyTickets;
    }
}
