using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;

    public abstract void Damage(int AttackDamage);
}
