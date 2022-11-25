using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{
    private float startTime;
    private float explosionArea;
    [SerializeField] GameObject explosionAnim;

    private float characterAttackDamage;
    private float fireBallDamage;

    
    public void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
        transform.Translate(GetPerpendicularDirection(transform.right) * Mathf.Sin(startTime * 4f) * speed * Time.deltaTime, Space.World);

        startTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Target>(out Target target))
        {
            target.GetHit(this);
            FireExplosion explosion = Instantiate(explosionAnim, gameObject.transform.position, Quaternion.identity).GetComponent<FireExplosion>();
            explosion.SetUp(explosionArea, fireBallDamage + characterAttackDamage * 0.5f);

            gameObject.SetActive(false);
        }
    }

    Vector2 GetPerpendicularDirection(Vector2 direction) 
    {
       return new Vector2(-direction.y, direction.x);
    }

    public void SetUp(Vector3 position, float fireBallDmg, float characterDamage, float area)
    {
        transform.position = position;
        characterAttackDamage = characterDamage;
        fireBallDamage = fireBallDmg; 
        attackDamage = fireBallDamage + characterAttackDamage * 2.0f;
        startTime = 0;
        transform.right = Random.insideUnitCircle.normalized;
        explosionArea = area;
    }

}
