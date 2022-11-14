using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : Weapon
{
    private const float consecutiveAttackCooldown = 0.1f;
    private bool attacking = false;
    [SerializeField] private uint extraShoots = 0;
    [SerializeField] private float attackCooldown;
    [SerializeField] float explosionArea;


    void Awake()
    {
        attackCooldown -= FindObjectOfType<PlayerDataManager>().GetCurrentUpgrade("attackspeed") * 0.03f;
    }

    public override void Attack()
    {
        if(!attacking)
            StartCoroutine(Fire());
    }

    public IEnumerator Fire()
    {
        Target target = findClosestTarget();
        
        if(target == null) yield break;

        Vector3 direction = (target.transform.position - character.transform.position).normalized;

        attacking = true;        
      
        StartCoroutine(Shoot(direction));

        yield return new WaitForSeconds(attackCooldown);

        attacking = false;
    }

    IEnumerator Shoot(Vector3 direction)
    {
        CreateFireBall(character.transform.position, direction, explosionArea);
        for (int i = 0; i < extraShoots; i++)
        {
            yield return new WaitForSeconds(consecutiveAttackCooldown);
            CreateFireBall(character.transform.position, direction, explosionArea);
        }
    }

    private void CreateFireBall(Vector3 position, Vector3 direction, float explosionArea)
    {
        FireBall fireBall = ObjectPool.SharedInstance.GetPooledObject(3).GetComponent<FireBall>();
        fireBall.SetUp(position, attackDamage, character.attackDamage, explosionArea);
    }
}
