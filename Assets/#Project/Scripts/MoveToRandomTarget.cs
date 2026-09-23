using UnityEngine;

public class MoveToRandomTarget : MoveToTargets
{
    override protected void MoveToNextDestination()
    {
        index = Random.Range(0, targets.Length);
        // if(index >= targets.Length) index = 0;
        agent.SetDestination(currentDestination);
    }
}
