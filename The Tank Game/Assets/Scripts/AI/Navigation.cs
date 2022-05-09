using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

    public Transform destination;

    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("navMesh agent component not present in" + gameObject.name);
        }

        navMeshAgent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (destination == null)
        {
            //get the nearest capture point   
        }


    }
}
