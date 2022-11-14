using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : Projectile
{

    Animator animator;

    float area;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(area, area, 1);
        animator.speed = 5;
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length / animator.speed); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Target>(out Target target))
        {
            target.GetHit(this);
        }
    }

    public void SetUp(float explosionArea, int damage)
    {
        area = explosionArea;
        attackDamage = damage;
    }

}
