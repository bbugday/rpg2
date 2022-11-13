using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponUpgrader 
{
    public string weaponName;
    public int weaponLevel = 0;
    public int maxWeaponLevel;
    public GameObject weaponPrefab;
    public string[] descriptions;
    public Weapon weapon;
    public MainCharacter mainCharacter;
    public Sprite sprite;

    public WeaponUpgrader(GameObject prefab, MainCharacter character)
    {
        weaponPrefab = prefab;
        mainCharacter = character;
    }

    public T InstantiateWeapon<T>() where T : Weapon
    {
        var weapon = GameObject.Instantiate(weaponPrefab).GetComponent<T>();
        weapon.transform.SetParent(mainCharacter.transform);
        return weapon;
    }

    public string ReadyUpgrade()
    {
        return descriptions[weaponLevel];
    }

    public bool IsUpgradeReady()
    {
        if(weaponLevel < maxWeaponLevel)
            return true;
        return false;
    }

    public abstract void Upgrade();

}
