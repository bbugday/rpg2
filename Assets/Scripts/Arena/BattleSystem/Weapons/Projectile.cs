using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public int attackDamage;
    public int force;
    public float speed;

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
