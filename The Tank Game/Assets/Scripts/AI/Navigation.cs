using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform destination;

    NavMeshAgent navMeshAgent;
    List<GameObject> capturePoints;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        capturePoints = new List<GameObject>();

        if (navMeshAgent == null)
        {
            Debug.LogError("navMesh agent component not present in" + gameObject.name);
        }



        //navMeshAgent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (false)
        {
            //get the nearest capture point   
        }

    }

    //to be used externaly
    public void StopToAttack()
    {
        SetNavDestination(transform.position);
    }

    private void GetClosesCapturePoint()
    {
        
        
        
    }

    private Vector3 OffSetDestination(Vector3 target)
    {


        return new Vector3();
    }

    private void SetNavDestination(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

}
