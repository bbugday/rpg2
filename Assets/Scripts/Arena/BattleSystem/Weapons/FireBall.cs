using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{

    private float startTime;

    [SerializeField] GameObject explosionAnim;
    
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
            Instantiate(explosionAnim, gameObject.transform.position, Quaternion.identity);

            gameObject.SetActive(false);
        }
    }

    Vector2 GetPerpendicularDirection(Vector2 direction) 
    {
       return new Vector2(-direction.y, direction.x);
    }

    public void SetUp(Vector3 position, int damage)
    {
        transform.position = position;
        attackDamage = damage;
        startTime = 0;
        transform.right = Random.insideUnitCircle.normalized;
    }

}
