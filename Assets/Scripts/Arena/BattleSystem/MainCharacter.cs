using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : BattleEntity, IAttackable
{
    private List<Weapon> weapons;

    public int attackDamage;

    [SerializeField] GameObject healthBar;

    [SerializeField] ArenaManager arenaManager;

    private int exp;
    private int level;

    private void Awake()
    {
        exp = 0;
        level = 1;
        health = maxHealth;

        weapons = new List<Weapon>();
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
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Collectable"))
        {
            collider.GetComponent<Collectable>()?.Collect(this);
        }
    }

}
