using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected MainCharacter character;

    public int attackDamage;

    public virtual void Attack(){}

    public void Start()
    {
        character = FindObjectOfType<MainCharacter>();
        character.AddWeapon(this);
    }

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
