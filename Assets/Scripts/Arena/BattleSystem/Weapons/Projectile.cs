using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int attackDamage;
    public int force;
    public float speed;

    public void SetUp(Vector3 direction, Vector3 position, int attackDamage)
    {
        SetDirection(direction);
        SetPosition(position);
        SetAttackDamage(attackDamage);
    }

    private void SetDirection(Vector3 direction)
    {
        transform.right = direction;
    }

    private void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void SetAttackDamage(int attackDamage)
    {
        this.attackDamage = attackDamage;
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
