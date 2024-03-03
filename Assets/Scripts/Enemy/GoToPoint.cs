using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToPoint : MonoBehaviour
{
    private List<Transform> returnPoints;
    private List<Transform> forwardPoints; 
    
    private bool moveBack;
    private NavMeshAgent agent;

    private void Awake()
    {
        returnPoints = EnemySpawn.Instance.SpawnPoints;
        forwardPoints = EnemySpawn.Instance.ForwardPoints;
    }

    private void Start() => agent = GetComponent<NavMeshAgent>();

    // Update is called once per frame
    void Update()
    {
        if (moveBack==true)
        {
            agent.SetDestination(returnPoints[Random.Range(0, returnPoints.Count - 2)].position);
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {                   
                    agent.SetDestination(forwardPoints[Random.Range(0, forwardPoints.Count - 2)].position);
                    moveBack = false;
                }
            }
        }
        else
        {
            agent.SetDestination(forwardPoints[Random.Range(0, forwardPoints.Count - 2)].position);
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {                   
                    moveBack = true;
                }
            }
        }
    }
}
