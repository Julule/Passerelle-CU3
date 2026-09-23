using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveToTargets : MonoBehaviour
{
    [SerializeField] protected Transform[] targets;

    protected int index = 0;
    protected UnityEngine.AI.NavMeshAgent agent;
    protected bool IsArrived => agent.remainingDistance <= agent.stoppingDistance;
    protected Vector3 currentDestination => targets[index].position;

    void Start (){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(currentDestination);

    }

    void Update()
    {
        if (IsArrived)
        {
            MoveToNextDestination();
        }
    }

    virtual protected void MoveToNextDestination(){

        index++; // attention, ++index est différent (inversé dans l'ordre de calcul). 
        if(index >= targets.Length) index = 0;
        agent.SetDestination(currentDestination);
    }


}
