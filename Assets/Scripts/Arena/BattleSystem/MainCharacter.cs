using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : BattleEntity, IAttackable
{
    private List<Weapon> weapons;

    public int attackDamage;
    public int armor;
    public int healthRegen;

    public List<WeaponUpgrader> weaponUpgraders;

    [SerializeField] GameObject healthBar;

    [SerializeField] ArenaManager arenaManager;

    [SerializeField] Gun gun;
    [SerializeField] FireWeapon fireWeapon;
    [SerializeField] KnifeThrower knifeThrower;
    [SerializeField] ArenaUiManager uiManager;

    int[] levelUpExps = new int[] {5,10,20,30,40,9999};

    public int exp;
    public int level;
    
    private bool dying = false;

    private void Awake()
    {
        exp = 0;
        healthRegen = 1;
        level = 1;
        armor = 0;

        PlayerDataManager dataManager = FindObjectOfType<PlayerDataManager>();

        maxHealth += dataManager.GetCurrentUpgrade("health") * 50;
        attackDamage += dataManager.GetCurrentUpgrade("attackdamage") * 10;
        armor += dataManager.GetCurrentUpgrade("armor") * 2;
        healthRegen += dataManager.GetCurrentUpgrade("healthregen") * 1;

        health = maxHealth;

        weapons = new List<Weapon>();
        
        weaponUpgraders = new List<WeaponUpgrader>();
        weaponUpgraders.Add(new GunUpgrader(gun.gameObject, this));
        weaponUpgraders.Add(new FireWeaponUpgrader(fireWeapon.gameObject, this));
        weaponUpgraders.Add(new KnifeUpgrader(knifeThrower.gameObject, this));

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

    void RegenHealth() 
    {
        if(health == maxHealth) return;

        var healthAfterRegen = health + healthRegen;
        health = healthAfterRegen > maxHealth ? maxHealth : healthAfterRegen;
        UpdateHealthBar();
    }

    public void GetHit(int damage)
    {
        Damage(damage - armor);
    }

    public override void Damage(int trueDamage)
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
        uiManager.LevelUp();
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
