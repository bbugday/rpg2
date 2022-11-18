using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    private const float consecutiveAttackCooldown = 0.1f;

    private bool attacking = false;
    
    public float attackCooldown;
    public uint bulletCount;
    public uint extraShoots = 0;

    void Awake()
    {
        attackCooldown -= FindObjectOfType<PlayerDataManager>().GetCurrentUpgrade("attackspeed") * 0.02f;
    }
    
    public override void Start()
    {
        base.Start();

        bulletCount = 1;
        extraShoots = 0;
        attackCooldown = 2;
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
        CreateMultiBullets(bulletCount);
        for (int i = 0; i < extraShoots; i++)
        {
            yield return new WaitForSeconds(consecutiveAttackCooldown);
            CreateMultiBullets(bulletCount);
        }
    }

    private void CreateMultiBullets(uint n)
    {
        Target target = findClosestTarget();
        
        if(target == null) return;

        Vector3 direction = (target.transform.position - character.transform.position);

        if(direction == Vector3.zero) direction = Vector3.right;

        Vector3 extraBulletPosition = (Quaternion.Euler(0, 0, 90) * direction).normalized;
        float extraBulletDistance = 0.3f;

        if(n % 2 == 0)
        {
            CreateBullet(character.transform.position + extraBulletPosition * extraBulletDistance / 2.0f, direction);
            CreateBullet(character.transform.position + extraBulletPosition * -extraBulletDistance / 2.0f , direction);
            
            for(int fired = 2, distance = 1; fired < n; fired += 2, distance++)
            {
                CreateBullet(character.transform.position + extraBulletPosition * (extraBulletDistance * distance + extraBulletDistance / 2f), direction);
                CreateBullet(character.transform.position + extraBulletPosition * -(extraBulletDistance * distance + extraBulletDistance / 2f), direction);
            }
        }
        else
        {
            CreateBullet(character.transform.position, direction);
            
            for(int fired = 1, distance = 1; fired < n; fired += 2, distance++)
            {
                CreateBullet(character.transform.position + extraBulletPosition * extraBulletDistance * distance, direction);
                CreateBullet(character.transform.position + extraBulletPosition * -extraBulletDistance * distance, direction);
            }
        }
    }

    private void CreateBullet(Vector3 position, Vector3 direction)
    {
        Bullet bullet = ObjectPool.SharedInstance.GetPooledObject(0).GetComponent<Bullet>();
        bullet.SetUp(direction, position, attackDamage + character.attackDamage);
    }
}
