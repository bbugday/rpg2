using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target, IAttackable
{
    [SerializeField] private int attackDamage;

    EnemyAnimator enemyAnimator;

    private SpriteRenderer spriteRenderer;

    MainCharacter mainCharacter;

    const float coolDownTime = 0.1f;
    bool onCoolDown;

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            if(!mainCharacter)
                mainCharacter = FindObjectOfType<MainCharacter>();
            Attack();
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player"))
        {
            if(!onCoolDown)
                StartCoroutine(AttackAndReload());
        }
    }

    public IEnumerator AttackAndReload()
    {
        Attack();
        onCoolDown = true;
        yield return new WaitForSeconds(coolDownTime);
        onCoolDown = false;
    }

    public void Attack()
    {
        mainCharacter.GetHit(attackDamage);
    }

}
