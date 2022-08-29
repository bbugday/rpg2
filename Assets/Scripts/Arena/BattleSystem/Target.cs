using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : BattleEntity
{
    public void GetHit(Projectile projectile)
    {
        Damage(projectile.attackDamage);
        PushBack(projectile.transform.right, projectile.force);
    }

    public override void Damage(int AttackDamage)
    {
        health -= AttackDamage;
    }

    public void PushBack(Vector3 direction, int force)
    {
        Vector3 velocity = (direction * force) * Time.deltaTime;
        transform.Translate(velocity);
    }
}
