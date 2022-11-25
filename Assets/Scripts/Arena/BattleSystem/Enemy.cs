using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Target, IAttackable
{
    [SerializeField] private int attackDamage;

    EnemyAnimator enemyAnimator;

    private SpriteRenderer spriteRenderer;

    MainCharacter mainCharacter;

    //[SerializeField] GameObject expObject;

    const float coolDownTime = 0.1f;
    bool onCoolDown;

    void Awake()
    {
        health = maxHealth;
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        enemyAnimator.Die();

        ExpObject expObject = ObjectPool.SharedInstance.GetPooledObject(2).GetComponent<ExpObject>();
        expObject.SetPosition(gameObject.transform.position);

        Destroy(GetComponent<EnemyController>());
        Destroy(this);

        //instantiate xp object
    }

    public override void GetHit(Projectile projectile)
    {
        StartCoroutine(enemyAnimator.WhiteSpriteEffect());
        Damage(projectile.attackDamage);
        PushBack(projectile.transform.right, projectile.force);

        enemyAnimator.GetDamage(projectile.attackDamage);
    }

    public override void Damage(float AttackDamage)
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
