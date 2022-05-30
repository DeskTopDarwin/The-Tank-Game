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

    private List<CaptureScript> capturePoints = new List<CaptureScript>();

    // Start is called before the first frame update
    void Start()
    {
        capturePoints = FindObjectsOfType<CaptureScript>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
