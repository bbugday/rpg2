using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : BattleEntity, IAttackable
{

    private List<Weapon> weapons;

    private int attackDamage;

    private void Awake()
    {
        weapons = new List<Weapon>();
    }

    private void Update()
    {
        if(FindObjectOfType<Target>())
            Attack();
    }

    public override void Damage()
    {

    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void Attack()
    {
        foreach(Weapon weapon in weapons)
        {
            weapon.Attack();
        }
    }



}
