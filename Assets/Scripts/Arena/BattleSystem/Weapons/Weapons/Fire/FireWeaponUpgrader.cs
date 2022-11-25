using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeaponUpgrader : WeaponUpgrader
{
    FireWeapon fireWeapon;
    
    public FireWeaponUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Fireweapon oluştur", "damage++"};
        maxWeaponLevel = 2;
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
            // case(2):
            //     fireWeapon.extraShoots++;
            //     break;
            // case(3):
            //     gun.attackDamage += 20;
            //     break;
            // case(4):
            //     gun.bulletCount++;
            //     break;
            // case(5):
            //     gun.extraShoots++;
            //     break;
            // case(6):
            //     gun.attackDamage += 25;
            //     break;
            // case(7):
            //     gun.bulletCount++;
            //     break;
            // case(8):
            //     gun.extraShoots++;
            //     break;
            // case(9):
            //     gun.attackDamage += 30;
            //     break;
            default:
                throw new UnityException("Invalid level");
        }

        weaponLevel++;
    }
}
