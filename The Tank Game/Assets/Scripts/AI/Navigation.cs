using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{


    public Transform destination;

    NavMeshAgent navMeshAgent;

    private int offset = 4;
    static List<GameObject> capturePoints;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //capturePoints = new List<GameObject>();
        if(capturePoints == null)
            capturePoints = FindGameObjectsWithLayer(LayerMask.NameToLayer("CapturePoint"));

        if (navMeshAgent == null)
        {
            Debug.LogError("navMesh agent component not present in" + gameObject.name);
        }


        //navMeshAgent.SetDestination(destination.position);
    }

    //finds all Capture points within the map
    static List<GameObject> FindGameObjectsWithLayer(int layer) 
    { 
        GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> goList = new List<GameObject>();

        for (int i = 0; i < goArray.Length; i++)
        { 
            if (goArray[i].layer == layer) 
                goList.Add(goArray[i]);
            
        } 
        
        if (goList.Count == 0)
            return null;
        
        return goList; 
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
        Vector3 closesPoint; ;
        float distance;

        //servers both as default value and initialisation
        closesPoint = capturePoints[0].transform.position;
        distance = closesPoint.magnitude;
        
        foreach (var point in capturePoints)
        {
            Vector3 betweenSelfAndPoint = transform.position - point.transform.position;
            float tempValue = betweenSelfAndPoint.magnitude;

            if (tempValue < distance)
            {
                distance = tempValue;
                closesPoint = point.transform.position;
            }
        }
        
        closesPoint =  OffSetDestination(closesPoint);
        SetNavDestination(closesPoint);
    }

    private Vector3 OffSetDestination(Vector3 target)
    {


        return target;
    }

    private void SetNavDestination(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

}
