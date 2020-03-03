using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindingAgentScript : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2.5f;
        goToTarget();
    }

    void Update()
    {
        Debug.Log(agent.remainingDistance);
        if (agent.remainingDistance > 1)
            goToTarget();
    }

    private void goToTarget()
    {
        agent.SetDestination(Target.position);
    }

}