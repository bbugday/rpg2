using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponUpgrader 
{
    public int weaponLevel = 0;
    public int maxWeaponLevel;
    public GameObject weaponPrefab;
    public string[] descriptions;
    public Weapon weapon;
    public MainCharacter mainCharacter;

    public WeaponUpgrader(GameObject prefab, MainCharacter character)
    {
        weaponPrefab = prefab;
        mainCharacter = character;
    }

    public T InstantiateWeapon<T>() where T : Weapon
    {
        var weapon = GameObject.Instantiate(weaponPrefab).GetComponent<T>();

        weapon.transform.SetParent(mainCharacter.transform);
        mainCharacter.AddWeapon(weapon);

        return weapon;
    }

    public abstract void Upgrade();
    public abstract string ReadyUpgrade();

}
