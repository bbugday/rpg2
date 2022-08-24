using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<Weapon> weapons;

    void Update()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.Attack(null);
        }
    }
}
