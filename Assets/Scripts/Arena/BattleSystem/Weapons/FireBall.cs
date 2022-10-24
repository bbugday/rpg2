using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);//bunun yerine sallanarak hareket
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Target>(out Target target))
        {
            target.GetHit(this);
            gameObject.SetActive(false);//bunun yerine patla
        }
    }
}
