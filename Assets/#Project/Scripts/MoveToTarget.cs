using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(target.position);
    }

}
