using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity : MonoBehaviour, IDamageable
{
    public float maxHealth;
    public float health;

    public abstract void Damage(float trueDamage);
}
