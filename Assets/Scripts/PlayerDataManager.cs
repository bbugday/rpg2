using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public Dictionary<string, PlayerStat> stats;

    public override void Awake()
    {
        base.Awake();

        stats = new Dictionary<string, PlayerStat>();

        stats.Add("movespeed", new PlayerStat());
        stats.Add("health", new PlayerStat());
        stats.Add("armor", new PlayerStat());
        stats.Add("cooldown", new PlayerStat());
        stats.Add("attackspeed", new PlayerStat());
        stats.Add("attackdamage", new PlayerStat());
    }

    public bool Upgrade(string statName)
    {
        return stats[statName].Upgrade();
    }

    public int GetCurrentUpgrade(string statName)
    {
        return stats[statName].currentUpgrade;
    }
}
