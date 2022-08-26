using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public virtual void Attack(){}

    protected Target findClosestTarget()
    {
        List<Target> targets = new List<Target>(FindObjectsOfType<Target>());
        Target closest = null;
        float distanceToClosest = Mathf.Infinity;

        foreach (Target target in targets)
        {
            float distance = (target.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToClosest > distance)
            {
                distanceToClosest = distance;
                closest = target;
            }
        }
        return closest;
    }
}
