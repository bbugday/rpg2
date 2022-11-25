using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : BattleEntity, IAttackable
{
    private List<Weapon> weapons;

    public float attackDamage;
    public float armor;
    public float healthRegen;

    public List<WeaponUpgrader> weaponUpgraders;

    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject expBar;

    [SerializeField] ArenaManager arenaManager;

    [SerializeField] Gun gun;
    [SerializeField] FireWeapon fireWeapon;
    [SerializeField] KnifeThrower knifeThrower;
    [SerializeField] ArenaUiManager uiManager;

    int[] levelUpExps = new int[] {10, 35, 50, 100, 150, 200, 250, 300, 350, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300,
        1400, 1500, 1600, 1700, 1800, 1900, 2100, 2300, 2500, 2700, 3500, 4000, 5000, 6000, 7000, 10000, 99999};

    public int exp;
    public int level;
    
    private bool dying = false;

    private void Awake()
    {
        SetStats();
        SetWeapons();
        uiManager = FindObjectOfType<ArenaUiManager>();
    }

    private void Start()
    {
        InvokeRepeating("RegenHealth", 1f, 1f);
    }

    private void Update()
    {
        if(FindObjectOfType<Target>())
            Attack();
    }

    private void SetStats()
    {
        exp = 0;
        healthRegen = 1;
        level = 1;
        armor = 0;
        maxHealth = 550;
        attackDamage = 60;

        PlayerDataManager dataManager = FindObjectOfType<PlayerDataManager>();

        maxHealth += dataManager.GetCurrentUpgrade("health") * 200;
        attackDamage += dataManager.GetCurrentUpgrade("attackdamage") * 20;
        armor += dataManager.GetCurrentUpgrade("armor") * 0.5f;
        healthRegen += dataManager.GetCurrentUpgrade("healthregen") * 2;

        health = maxHealth;
    }

    private void SetWeapons()
    {
        weapons = new List<Weapon>();
        
        weaponUpgraders = new List<WeaponUpgrader>();
        weaponUpgraders.Add(new GunUpgrader(gun.gameObject, this));
        weaponUpgraders.Add(new FireWeaponUpgrader(fireWeapon.gameObject, this));
        weaponUpgraders.Add(new KnifeUpgrader(knifeThrower.gameObject, this));
    }

    private void RegenHealth() 
    {
        if(health == maxHealth) return;

        var healthAfterRegen = health + healthRegen;
        health = healthAfterRegen > maxHealth ? maxHealth : healthAfterRegen;
        UpdateHealthBar();
    }

    public void GetHit(float damage)
    {
        Damage(damage - armor);
    }

    public override void Damage(float trueDamage)
    {
        if(trueDamage <= 0) return;
        health -= trueDamage;
        UpdateHealthBar();
        if(health <= 0 && !dying)
        {
            Die();
        }
    }

    private void Die()
    {
        dying = true;
        arenaManager.dieEvent();
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3((health / (float)maxHealth), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    private void UpdateExpBar()
    {
        if(level > 1)
            expBar.transform.localScale = new Vector3(((exp - levelUpExps[level - 2]) / ((float)(levelUpExps[level - 1] - levelUpExps[level - 2]))), expBar.transform.localScale.y, expBar.transform.localScale.z);
        else
            expBar.transform.localScale = new Vector3(exp / (float)(levelUpExps[level - 1]), expBar.transform.localScale.y, expBar.transform.localScale.z);
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void Attack()
    {
        if(weapons.Count == 0) return;
        foreach(Weapon weapon in weapons)
        {
            weapon.Attack();
        }
    }

    public void AddExp(int exp)
    {
        this.exp += exp;
        //arenaManager.GainExp(exp);
        CheckLevelUp();
        UpdateExpBar();
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
        LevelUpStats();
        uiManager.LevelUp();

        CheckLevelUp();
    }

    private void LevelUpStats()
    {
        maxHealth += 100;
        health += 100;
        attackDamage += 5f;
        UpdateHealthBar();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Collectable"))
        {
            collider.GetComponent<Collectable>()?.Collect(this);
        }
    }

}
