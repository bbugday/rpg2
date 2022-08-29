using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : BattleEntity, IAttackable
{

    private List<Weapon> weapons;

    public int attackDamage;

    private void Awake()
    {
        weapons = new List<Weapon>();
    }

    private void Update()
    {
        if(FindObjectOfType<Target>())
            Attack();
    }

    public override void Damage(int AttackDamage)
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
