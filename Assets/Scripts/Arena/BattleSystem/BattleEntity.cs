using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleEntity : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    public abstract void Damage();
}
