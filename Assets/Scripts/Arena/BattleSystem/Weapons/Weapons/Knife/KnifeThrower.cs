using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : Weapon
{
    private const float consecutiveAttackCooldown = 0.1f;

    private bool attacking = false;
    
    [SerializeField] private float attackCooldown;
    [SerializeField] private uint knifeCount;
    [SerializeField] private uint extraShoots = 0;

    CharacterAnimator animator;

    Vector3 lastDirection = Vector3.right;

    void Awake()
    {
        animator = FindObjectOfType<CharacterAnimator>();
        attackCooldown -= FindObjectOfType<PlayerDataManager>().GetCurrentUpgrade("attackspeed") * 0.01f;
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
        CreateMultiKnifes(knifeCount);
        for (int i = 0; i < extraShoots; i++)
        {
            yield return new WaitForSeconds(consecutiveAttackCooldown);
            CreateMultiKnifes(knifeCount);
        }
    }

    private void CreateMultiKnifes(uint n)
    {
        
        if(animator.MoveX != 0)
            lastDirection = animator.MoveX == 1 ? Vector3.right : Vector3.left;
        else if(animator.MoveY != 0)    
            lastDirection = animator.MoveY == 1 ? Vector3.up : Vector3.down;

        Vector3 direction = lastDirection;
        //if(direction == Vector3.zero) direction = Vector3.right;

        Vector3 extraBulletPosition = (Quaternion.Euler(0, 0, 90) * direction).normalized;
        float extraBulletDistance = 0.3f;

        if(n % 2 == 0)
        {
            CreateKnife(character.transform.position + extraBulletPosition * extraBulletDistance / 2.0f, direction);
            CreateKnife(character.transform.position + extraBulletPosition * -extraBulletDistance / 2.0f , direction);
            
            for(int fired = 2, distance = 1; fired < n; fired += 2, distance++)
            {
                CreateKnife(character.transform.position + extraBulletPosition * (extraBulletDistance * distance + extraBulletDistance / 2f), direction);
                CreateKnife(character.transform.position + extraBulletPosition * -(extraBulletDistance * distance + extraBulletDistance / 2f), direction);
            }
        }
        else
        {
            CreateKnife(character.transform.position, direction);
            
            for(int fired = 1, distance = 1; fired < n; fired += 2, distance++)
            {
                CreateKnife(character.transform.position + extraBulletPosition * extraBulletDistance * distance, direction);
                CreateKnife(character.transform.position + extraBulletPosition * -extraBulletDistance * distance, direction);
            }
        }
    }

    private void CreateKnife(Vector3 position, Vector3 direction)
    {
        Knife knife = ObjectPool.SharedInstance.GetPooledObject(4).GetComponent<Knife>();
        knife.SetUp(direction, position, attackDamage + character.attackDamage);

        // Bullet bullet = ObjectPool.SharedInstance.GetPooledObject(4).GetComponent<Bullet>();
        // bullet.SetUp(direction, position, attackDamage + character.attackDamage);
    }

}
