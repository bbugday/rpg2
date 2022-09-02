using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target, IAttackable
{
    [SerializeField] private int attackDamage;

    EnemyAnimator enemyAnimator;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    void Update()
    {
        if(health <= 0)
        {
            enemyAnimator.Die();
            Destroy(GetComponent<EnemyController>());
            Destroy(this);
        }
    }

    public override void GetHit(Projectile projectile)
    {
        StartCoroutine(enemyAnimator.WhiteSpriteEffect());
        Damage(projectile.attackDamage);
        PushBack(projectile.transform.right, projectile.force);

        enemyAnimator.GetDamage(projectile.attackDamage);
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


    public void Attack()
    {

    }

}
