using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeaponUpgrader : WeaponUpgrader
{
    FireWeapon fireWeapon;
    
    public FireWeaponUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Create Fire Weapon", "Increase damage", "Extra shoot", "Increase area",
                                         "Increase damage", "Extra shoot", "Increase area",
                                         "Increase damage", "Extra shoot", "Increase area"};
        maxWeaponLevel = 10;
        weaponName = "Fire Weapon";
        sprite = Resources.Load<Sprite>("images/fireball3");
    }

    public override void Upgrade()
    {
        switch (weaponLevel)
        {
            case(0):
                fireWeapon = InstantiateWeapon<FireWeapon>();
                break;
            case(1):
                fireWeapon.attackDamage += 5;
                break;
            case(2):
                fireWeapon.extraShoots++;
                break;
            case(3):
                fireWeapon.explosionArea += 2.5f;
                break;
            case(4):
                fireWeapon.attackDamage += 5;
                break;
            case(5):
                fireWeapon.extraShoots++;
                break;
            case(6):
                fireWeapon.explosionArea += 2.5f;
                break;
            case(7):
                fireWeapon.attackDamage += 5;
                break;
            case(8):
                fireWeapon.extraShoots++;
                break;
            case(9):
                fireWeapon.explosionArea += 2.5f;
                break;
            default:
                throw new UnityException("Invalid level");
        }

        weaponLevel++;
    }
}
