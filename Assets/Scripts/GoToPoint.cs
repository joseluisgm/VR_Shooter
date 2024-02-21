using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToPoint : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;  
    public bool moveBack;
    public NavMeshAgent agent; 
    // Update is called once per frame
    void Update()
    {
        if (moveBack==true)
        {
            agent.SetDestination(pointA.position);
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {                   
                    agent.SetDestination(pointB.position);
                    moveBack = false;
                }
            }
        }
        else
        {
            agent.SetDestination(pointB.position);
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
