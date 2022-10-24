using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity : MonoBehaviour, IDamageable
{
    public int maxHealth;
    public int health;

    public abstract void Damage(int AttackDamage);
}
