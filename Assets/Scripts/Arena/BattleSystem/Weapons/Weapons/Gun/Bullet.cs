using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Target>(out Target target))
        {
            target.GetHit(this);
            gameObject.SetActive(false);
        }
    }

    public void SetUp(Vector3 direction, Vector3 position, float attackDamage)
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

    private void SetAttackDamage(float attackDamage)
    {
        this.attackDamage = attackDamage;
    }

}
