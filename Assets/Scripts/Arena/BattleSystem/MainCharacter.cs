using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : BattleEntity, IAttackable
{
    private List<Weapon> weapons;

    public int attackDamage;

    public List<WeaponUpgrader> weaponUpgraders;

    [SerializeField] GameObject healthBar;

    [SerializeField] ArenaManager arenaManager;

    [SerializeField] Gun gun;
    [SerializeField] FireWeapon fireWeapon;


    int[] levelUpExps = new int[] {22,444,666,888};

    public int exp;
    public int level;

    private void Awake()
    {
        exp = 0;
        level = 1;
        health = maxHealth;

        weapons = new List<Weapon>();
        
        weaponUpgraders = new List<WeaponUpgrader>();
        weaponUpgraders.Add(new GunUpgrader(gun.gameObject, this));
        weaponUpgraders.Add(new FireWeaponUpgrader(fireWeapon.gameObject, this));
    }

    private void Start()
    {
        //weaponUpgraders[1].Upgrade();
    }

    private void Update()
    {
        if(FindObjectOfType<Target>())
            Attack();
    }

    public void GetHit(int damage)
    {
        Damage(damage);
    }

    public override void Damage(int damage)
    {
        health -= damage;
        UpdateHealthBar();
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        arenaManager.dieEvent();
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3((health / (float)maxHealth), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
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

    public void AddExp(int exp)
    {
        this.exp += exp;
        arenaManager.GainExp(exp);
        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if(exp >= levelUpExps[level - 1])
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        Debug.Log("level up:" + level);

        CheckLevelUp();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Collectable"))
        {
            collider.GetComponent<Collectable>()?.Collect(this);
        }
    }

}
