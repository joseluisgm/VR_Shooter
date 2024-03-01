using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform plant;
    [SerializeField] private Transform plantTarget;
    [SerializeField] private Transform manure;
    [SerializeField] private float manureIncrement;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float rollSpeed;

    private float manureSize = 0;

    private NavMeshAgent agent;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = plant.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float agentVelocity = agent.velocity.magnitude;

        anim.speed = agentVelocity * walkSpeed;
        manure.Rotate(Vector3.right * agentVelocity * rollSpeed * Time.deltaTime);

        manureSize += agentVelocity * manureIncrement * Time.deltaTime;
        manure.parent.transform.localScale = Vector3.one * manureSize;
        plant.transform.position = plantTarget.position;

    }
}
