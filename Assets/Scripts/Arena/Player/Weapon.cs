using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : IAttackable
{
    public void Attack(IDamageable target)
    {
        target.Damage();
    }
}
