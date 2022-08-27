using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsDB", menuName = "ScriptableObjects/ObjectsDB", order = 1)]
public class ObjectsDB : ScriptableObject
{
    Dictionary<string, ArenaSO> arenas;

    void OnEnable()
    {
        arenas = new Dictionary<string, ArenaSO>();
    }

    public void AddArena(string arenaName, ArenaSO arenaData)
    {   
        if(!arenas.ContainsKey(arenaName))
            arenas.Add(arenaName, arenaData);
    }

    public ArenaSO GetArena(string arenaName)
    {
        return arenas[arenaName];
    }

}
