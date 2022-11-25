using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : Weapon
{
    private const float consecutiveAttackCooldown = 0.1f;
    private bool attacking = false;

    public uint extraShoots;
    public float attackCooldown;
    public float explosionArea;


    public override void Start()
    {
        base.Start();

        attackDamage = 20;
        extraShoots = 0;
        attackCooldown = 4;
        explosionArea = 3;
        attackCooldown -= FindObjectOfType<PlayerDataManager>().GetCurrentUpgrade("attackspeed") * 0.1f;
    }

    public override void Attack()
    {
        if(!attacking)
            StartCoroutine(Fire());
    }

    public IEnumerator Fire()
    {
        attacking = true;        
      
        StartCoroutine(Shoot());

        yield return new WaitForSeconds(attackCooldown);

        attacking = false;
    }

    IEnumerator Shoot()
    {
        CreateFireBall(character.transform.position, explosionArea);
        for (int i = 0; i < extraShoots; i++)
        {
            yield return new WaitForSeconds(consecutiveAttackCooldown);
            CreateFireBall(character.transform.position, explosionArea);
        }
    }

    private void CreateFireBall(Vector3 position, float explosionArea)
    {
        FireBall fireBall = ObjectPool.SharedInstance.GetPooledObject(3).GetComponent<FireBall>();
        fireBall.SetUp(position, attackDamage, character.attackDamage, explosionArea);
    }
}
