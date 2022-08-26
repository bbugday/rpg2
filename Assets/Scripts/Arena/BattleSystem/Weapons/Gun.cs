using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    private bool attacking = false;
    private float consecutiveAttackCooldown = 0.1f;

    [SerializeField] private float attackCooldown;
    [SerializeField] private uint bulletCount;
    [SerializeField] private uint extraShoots = 0;

    public void Start()
    {
        FindObjectOfType<MainCharacter>().AddWeapon(this);
    }

    // private void Update()
    // {
    //     if(!attacking && FindObjectOfType<Target>())
    //         Attack();
    // }

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
        CreateBullet();
        for (int i = 0; i < extraShoots; i++)
        {
            yield return new WaitForSeconds(consecutiveAttackCooldown);
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        var bullet = ObjectPool.SharedInstance.GetPooledObject(0).GetComponent<Bullet>();
        bullet.transform.position = this.transform.position;

        Target target = findClosestTarget();
        bullet.transform.right = target.transform.position - transform.position;
    }

}
